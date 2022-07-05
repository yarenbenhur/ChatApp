using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;

namespace ChatApp.Controllers
{
    public class RabbitMQController : Controller
    {
        public IConnection GetConnecion()
        {
            ConnectionFactory factory = new()
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
            return factory.CreateConnection();

        }

        public bool Send(IConnection conn, string message, string friendqueue)
        {
            try
            {
                IModel channel = conn.CreateModel();
                channel.ExchangeDeclare("ex.direct", ExchangeType.Direct);
                channel.QueueDeclare(friendqueue, true, false, false, null);
                channel.QueueBind(friendqueue, "ex.direct", friendqueue, null);
                channel.BasicPublish("ex.direct", friendqueue, null, Encoding.UTF8.GetBytes(message));
            }
            catch (Exception)
            {

            }
            return true;
            



        }
        public string Receive(IConnection con, string myqueue)
        {
            try
            {
                string queue = myqueue;
                IModel channel = con.CreateModel();
                channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                BasicGetResult result = channel.BasicGet(queue: queue, autoAck: true);
                if (result != null)
                    return Encoding.UTF8.GetString(result.Body.Span);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;

            }

        }
    }
}

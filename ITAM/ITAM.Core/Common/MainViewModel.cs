using ConfigReader.Entities;

namespace LT.Core.Common
{
    /// <summary>
    /// Most important class, which would be used to send the response for any action being implemented in entire application
    /// It has two major peroperties which can be sent as response of any action method across the application
    /// First property name is Data which can be of Type T
    /// Second property name is Message which is of Type Message Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MainViewModel<T>
    {
        public T Data { get; set; }
        public Message Message { get; }

        public MainViewModel()
        {
        }

        public MainViewModel(Message message)
        {
            Message = message;
        }

        public MainViewModel(T entity, Message message)
        {
            Message = message;
            Data = entity;
        }

        public MainViewModel(T entity)
        {
            Data = entity;
        }
    }
}

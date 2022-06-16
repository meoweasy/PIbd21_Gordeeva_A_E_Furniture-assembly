using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureAssemblyContracts.Attributes;

namespace FurnitureAssemblyContracts.ViewModels
{
    // Сообщения, приходящие на почту
    public class MessageInfoViewModel
    {
        public string MessageId { get; set; }

        [Column(title: "Отправитель", width: 100)]
        public string SenderName { get; set; }

        [Column(title: "Дата письма", width: 150)]
        public DateTime DateDelivery { get; set; }

        [Column(title: "Заголовок", width: 150)]
        public string Subject { get; set; }

        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Body { get; set; }
    }
}

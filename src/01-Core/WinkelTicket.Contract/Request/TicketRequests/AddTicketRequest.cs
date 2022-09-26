using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WinkelTicket.Core.Dtos;
using WinkelTicket.Enumeration.Enums;

namespace WinkelTicket.Contract.Request.TicketRequests
{
    public class AddTicketRequest
    {
        [Required(ErrorMessage = "Başlış alanı boş bırakılamaz")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Zaman Sınırı")]
        public string isTimeLimited { get; set; }

        [Display(Name = "Son Tarih")]
        [DataType(DataType.Date)]
        public DateOnly EndDate { get; set; }

        [Display(Name = "Öncelik")]
        public EnumTicketPriority Priority { get; set; }

        [Required(ErrorMessage = "En az bir tane kullanıcı seçiniz")]
        [Display(Name = "Görevden Sorumlu Kişiler")]
        public List<string> Assignees { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklama Ekleyin")]
        [Display(Name = "Açıklama")]      
        public string Description { get; set; }
        public string CreatorId { get; set; }

    }
}
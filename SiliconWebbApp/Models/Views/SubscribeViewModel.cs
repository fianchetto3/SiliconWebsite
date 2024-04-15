﻿using System.ComponentModel.DataAnnotations;

namespace SiliconWebbApp.Models.Views;

public class SubscribeViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "E-mail address", Prompt = "Your Email")]
    public string Email { get; set; } = null!;

    public bool DailyNewsLetter { get; set; }   
    
    public bool AdervtisingUpdates { get; set; }

    public bool WeekInReview { get; set; }

    public bool EventUpdates { get; set; }

    public bool StartupsWeekly { get; set; }

    public bool Podcasts { get; set; }


}

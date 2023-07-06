using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Awoo.Shared;

public class Availibility
{
    [Key]
    public int Id { get; set; } = 1000;

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:u}")]
    public DateTime DateTime { set; get; } = DateTime.Now;
    
    public TimeSpan Duration { set; get; } = TimeSpan.FromDays(2);

    public CalanderStates State { set; get; } = CalanderStates.No;
    
    public User Player { get; set; }
    [ForeignKey("Player")]
    public int PlayerId { get; set; }
}
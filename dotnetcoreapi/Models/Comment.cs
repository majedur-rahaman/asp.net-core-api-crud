
using System.ComponentModel.DataAnnotations.Schema;
using dotnetcoreapi.Models;

[Table("Comments")]
public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public int? StockId { get; set; }
    //Navigation Property
    public Stock? Stock { get; set; }
    public string AppUserId { get; set; }
    public AppUser appUser { get; set; }
}
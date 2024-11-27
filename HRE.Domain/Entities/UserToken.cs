
using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class UserToken
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(max)")]
    public string Token { get; set; } = default!;

    [Column(TypeName = "varchar(50)")]
    public string TokenType { get; set; } = default!;
    [Column(TypeName = "varchar(255)")]
    public string Email { get; set; } = default!;
    public DateTime ExpirationDate { get; set; } = DateTime.Now.AddMinutes(5);

    public bool IsUsed { get; set; } = false;

    public int UserId { get; set; }

    public User User { get; set; } = default!;
}

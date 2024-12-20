﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HRE.Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Column(TypeName = "Varchar(255)")]
    public string Fullname { get; set; } = default!;

    [Column(TypeName = "Varchar(100)")]
    public string Username { get; set; } = default!;
    [Column(TypeName = "Varchar(255)")]
    public string Email { get; set; } = default!;
    [Column(TypeName = "NVarchar(max)")]
    public string Password { get; set; } = default!;
    public bool Status { get; set; } = false;
    public DateTime DateAdded { get; set; } = DateTime.Now;

    public int RoleId {  get; set; }
    public Role Role { get; set; } = default!;
    public ICollection<UserToken> UserTokens { get; set; } = default!;
    public ICollection<UserInteraction> UserInteractions { get; set; } = default!;
    public ICollection<GiftRedemption> GiftRedemptionUsers { get; set; } = default!;
    public ICollection<GiftRedemption> GiftRedemptionPGs { get; set; } = default!;
    public ICollection<GiftReturn> GiftReturns { get; set; } = default!;
}

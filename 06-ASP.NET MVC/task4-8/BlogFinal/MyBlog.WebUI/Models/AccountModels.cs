using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MyBlog.WebUI.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("UsersContext")
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }
        public DbSet<AboutSelf> AboutSelf { get; set; }
        public DbSet<Votes> Votes { get; set; }
    }

    [Table("Users")]
    public class Users
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Display(Name = "Ник")]
        public string UserName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public bool Active { get; set; }
    }
    [Table("AboutSelf")]
    public class AboutSelf
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Hobbies { get; set; }
        public string About { get; set; }
    }
    [Table("Feedbacks")]
    public class Feedbacks
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Отзыв")]
        public string FeedbackText { get; set; }
        public string DateTime { get; set; }
    }
    [Table("Votes")]
    public class Votes
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Rate { get; set; }
    }
    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Ник")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должен состоять хотя бы из {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и подтверждение не совпадают")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Ник")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Вы не ввели Ник")]
        [Display(Name = "Ник")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ник должен быть от 3 до 50 символов")]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "используйте только латинские буквы и/или цифры")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Вы не ввели Пароль")]
        [StringLength(100, ErrorMessage = "{0} должен состоять хотя бы из {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение не совпадают")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Вы не ввели E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "не является E-mail адресом")]
        public string Email { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}

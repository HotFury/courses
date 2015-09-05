using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Entities
{
    [MetadataTypeAttribute(typeof(Users.UsersMetadata))]
    public partial class Users
    {
        internal sealed class UsersMetadata
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Вы не ввели Ник")]
            [StringLength(10, MinimumLength = 3, ErrorMessage = "Ник должен быть от 3 до 10 символов")]
            [RegularExpression(@"[a-z0-9]+", ErrorMessage = "используйте только латинские буквы и/или цифры")]
            [Display(Name = "Ник:")]
            public string Nick { get; set; }
            [Required(ErrorMessage = "Вы не ввели E-mail")]
            [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "не является E-mail адресом")]
            [Display(Name = "E-mail:")]
            public string Email { get; set; }
        }
    }
}

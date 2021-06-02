using System.ComponentModel.DataAnnotations;

namespace Wangkanai.Webmaster.Models
{
    public enum GravatarMode
    {
        [Display(Name = "404")]
        NotFound,

        [Display(Name = "Mp")]
        Mp,

        [Display(Name = "Identicon")]
        Identicon,

        [Display(Name = "Monsterid")]
        Monsterid,

        [Display(Name = "Wavatar")]
        Wavatar,

        [Display(Name = "Retro")]
        Retro,

        [Display(Name = "Blank")]
        Blank,

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        Default
    }
}
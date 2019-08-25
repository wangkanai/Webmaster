using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangkanai.Webmaster.Core.Drawing
{
    public static class ImageConvertor
    {
        private static string GetFileContentType(string path)
        {
            if (path.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                return "image/jpeg";
            if (path.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                return "image/gif";
            if (path.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                return "image/png";
            if (path.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                return "image/svg";
            throw new ArgumentException("Unknown file type");
        }

        public static HtmlString InlineImage(this IHtmlHelper html, string path, object attributes = null)
        {
            if (html == null)
                throw new ArgumentNullException(nameof(html));

            var contentType = GetFileContentType(path);

            var env = html.ViewContext.HttpContext.RequestServices.GetService(typeof(IHostEnvironment)) as IHostEnvironment;

            using (var stream = env.ContentRootFileProvider.GetFileInfo(path).CreateReadStream())
            {
                var array = new byte[stream.Length];
                stream.Read(array, 0, array.Length);
                var base64 = Convert.ToBase64String(array);

                var props = (attributes != null)
                    ? attributes.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(attributes))
                    : null;
                var attrs = (props == null) 
                    ? string.Empty 
                    : string.Join(" ", props.Select(x => string.Format("{0}=\"{1}\"", x.Key, x.Value)));

                var img = $"<img src=\"data:{contentType};base64,{base64}\" {attrs}";

                return new HtmlString(img);
            }
        }
    }
}

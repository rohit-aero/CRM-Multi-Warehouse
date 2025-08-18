using System;
using System.Web;

public class ImageHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string imagePath = context.Request.QueryString["imagePath"];
        string fileExtension = System.IO.Path.GetExtension(imagePath).ToLowerInvariant();

        if (!System.IO.File.Exists(imagePath))
        {
            return;
        }
        switch (fileExtension)
        {
            case ".jpg":
            case ".jpeg":
                context.Response.ContentType = "image/jpeg";
                break;
            case ".png":
                context.Response.ContentType = "image/png";
                break;
            default:
                throw new ArgumentException("Unsupported file extension.");
        }

        context.Response.WriteFile(imagePath);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}

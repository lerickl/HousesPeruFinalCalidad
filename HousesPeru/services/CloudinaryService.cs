using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HousesPeru.services
{
    public interface ICloudinaryService
    {
        string uploadImg(HttpPostedFileBase imagePath);
    }
    public class CloudinaryService: ICloudinaryService
    {
        public static Cloudinary cloudinary;
        Account account = new Account(
                "casas",
                "663463693755741",
                "oETSBAsbZc4l_NcThWacRIGtXXA"
            );
        public CloudinaryService()
        {
            cloudinary = new Cloudinary(account);
        }

        public string uploadImg(HttpPostedFileBase imagePath) 
        {

                var uploadImg = new ImageUploadParams()
                {
                    File = new FileDescription(imagePath.FileName,imagePath.InputStream)
                };
                 
                var uploadResult = cloudinary.Upload(uploadImg).Uri;
                var dato = uploadResult;
                return dato.ToString();
      
        
        }
    }


}
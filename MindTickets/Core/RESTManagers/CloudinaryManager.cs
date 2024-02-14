using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.RESTManagers
{
    public class CloudinaryManager
    {


        public static Cloudinary cloudinary;
        public const string CLOUD_NAME = "csalazarg";
        public const string API_KEY = "823831892168866";
        public const string API_SECRET = "QonchzbsDRyA5NT-HQfjIMLg4Sk";
        public string imagePath;


        public void CloudinaryStorage()
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new Cloudinary(account);
            uploadImage(imagePath);

        }
       
        public static void uploadImage(string imagePath)
        {
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imagePath)
                };

                var uploadResult = cloudinary.Upload(uploadParams);
                Console.WriteLine("[Image was uploaded successfully]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

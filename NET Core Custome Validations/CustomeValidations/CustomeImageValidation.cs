using Microsoft.AspNetCore.Http;
using NET_Core_Custome_Validations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_Custome_Validations.CustomeValidations
{
    public class CustomeImageValidation : ValidationAttribute
    {
        private readonly List<ImageFormat> ImageFormatList;
        private const int MAX_FILE_SIZE = 2097152;//2 mb

        public CustomeImageValidation()
        {
            ImageFormatList = new List<ImageFormat> 
                { ImageFormat.Png, ImageFormat.Jpeg };
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                Profile profile = null;

                if(validationContext.ObjectInstance is Profile)
                {
                    profile = validationContext.ObjectInstance as Profile;
                    var profileImage = profile.ProfileImage;

                    if (IsSizeValid(profileImage))
                    {
                        if (IsFileValidImage(profileImage))
                            return ValidationResult.Success;


                        return new ValidationResult
                            ("File needs to be in a valid Image format (Png,Jpeg)");
                    }

                    return new ValidationResult
                        ("File saize is not valid (bigger than 2 mb)");
                }


                return new ValidationResult
                    ("Something went wrong processing the request");
            }
            catch (Exception)
            {
                return new ValidationResult
                    ("Something went wrong processing the request");
            }
        }

        private bool IsSizeValid(IFormFile file)
        {
            using (var memStream = new MemoryStream())
            {
                file.CopyTo(memStream);

                if(memStream.Length < MAX_FILE_SIZE)
                {
                    return true;
                }

                return false;
            }
        }

        private bool IsFileValidImage(IFormFile file)
        {
            try
            {
                var uplaodedImage = Image.FromStream(file.OpenReadStream());

                if(ImageFormatList.Any(x => x.Equals(uplaodedImage.RawFormat)))
                    return true;


                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

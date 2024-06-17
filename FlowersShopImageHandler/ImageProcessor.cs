using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;
using System.Threading.Tasks;

namespace FlowersShopImageHandler
{
    public class ImageProcessor
    {
       
        public readonly string _outputPathSmall;
        public readonly string _outputPathLarge;
        private readonly Size _smallSize = new Size(640, 480);
        private readonly Size _largeSize = new Size(1280, 960);

        public ImageProcessor(string outputPathSmall, string outputPathLarge)
        {
            _outputPathSmall = outputPathSmall;
            _outputPathLarge = outputPathLarge;
            CreateOutputDirectories();
        }

        public async Task ProcessImageAsync(string imagePath)
        {
            try
            {
                if (IsImageFile(imagePath)) // Проверяем, является ли файл изображением
                {
                    using (var image = Image.Load(imagePath))
                    {
                        ResizeAndSaveImage(imagePath, _smallSize, _outputPathSmall, image);
                       
                        ResizeAndSaveImage(imagePath, _largeSize, _outputPathLarge, image);                                            
                    }
                    await Task.Delay(5000);
                    File.Delete(imagePath);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private void ResizeAndSaveImage(string imagePath, Size size, string outputPath, Image image) 
        {           
            var resizedImage = ResizeImage(image, size);
            var outputFileName = Path.GetFileNameWithoutExtension(imagePath) + ".jpg";
            var fullOutputPath = Path.Combine(outputPath, outputFileName);
            resizedImage.Save(fullOutputPath, new JpegEncoder());
        }


        private bool IsImageFile(string filePath)
        {
            try
            {
                using (var img = Image.Load(filePath))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private Image ResizeImage(Image image, Size size)
        {
            var resizeOptions = new ResizeOptions
            {
                Size = size,
                Mode = ResizeMode.Max,
                Sampler = KnownResamplers.Lanczos3,
                Compand = true,               
            };
            image.Mutate(x => x.Resize(resizeOptions));
            return image;
        }
        private void CreateOutputDirectories()
        {
            if (!Directory.Exists(_outputPathSmall))
            {
                Directory.CreateDirectory(_outputPathSmall);
            }

            if (!Directory.Exists(_outputPathLarge))
            {
                Directory.CreateDirectory(_outputPathLarge);
            }
        }
    }
}

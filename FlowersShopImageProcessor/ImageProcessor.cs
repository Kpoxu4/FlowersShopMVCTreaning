using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace FlowersShopMVCTraining.ImageProcessor
{
    public class ImageProcessor
    {

        public readonly string _outputPathSmall;
        public readonly string _outputPathLarge;
        private readonly Size _smallSize;
        private readonly Size _largeSize;

        public ImageProcessor(string outputPathSmall, string outputPathLarge, Size smallSize, Size largeSize)
        {
            _outputPathSmall = outputPathSmall;
            _outputPathLarge = outputPathLarge;
            _smallSize = smallSize;
            _largeSize = largeSize;
            CreateOutputDirectories();
        }    

        public async Task ProcessImageAsync(string imagePath)
        {
            try
            {
                if (IsImageFile(imagePath))
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
                Mode = ResizeMode.Crop, 
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

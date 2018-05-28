namespace UserInterfaceLayer.MarkupExtension
{
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [ContentProperty("SourceImage")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string SourceImage { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (SourceImage == null)
                return null;

            string imagePath;
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    imagePath = SourceImage;
                    break;
                case Device.iOS:
                    imagePath = SourceImage + ".png";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return imagePath;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}

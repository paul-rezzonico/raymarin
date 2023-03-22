using Xamarin.Forms;

namespace XXXXXX
{
    public class Page1ViewModel : BaseViewModel
    {
        #region Instance

         public static Page1ViewModel Instance { get; } = new Page1ViewModel();

         #endregion

         public Page1ViewModel()
         {
             firstColor = Color.Aqua;
             secondColor = Color.Chartreuse;
         }

         public Color firstColor
         {
             get
             {
                 return GetValue<Color>();
             }
             set
             {
                 SetValue(value);
             }
         }

         public Color secondColor
         {
             get
             {
                 return GetValue<Color>();
             }
             set
             {
                 SetValue(value);
             }
         }
         
         public void UpdateColor()
         {
             if (firstColor == Color.Aqua)
             {
                 firstColor = Color.Chartreuse;
                 secondColor = Color.Aqua;
             }
             else
             {
                 firstColor = Color.Aqua;
                 secondColor = Color.Chartreuse; 
             } 
         }
    }
    
}
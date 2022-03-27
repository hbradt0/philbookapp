using CoreGraphics;
using EmailReader;
using Foundation;
using System;
using UIKit;

namespace phillBookApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ViewDidLoad1();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public UITextView textView;
        public UITextView booktextView;
        public UITextView textView2;
        public UITextField editTextWrite;
        public UITextView textViewWrite;

        public UIButton Button1;
        public UIButton Button2;
        public UIButton Button3;
        public UIButton Buttonbackyourstory;
        public UIButton Buttonyourstoryscreen;
        public UIButton ButtonyourstoryscreenUpload;
        public UIButton ButtonDelete;
        public UIButton ButtonShare;

        public UIImageView imageView;
        public UIView View1;
        public UIView View2;
        public UIView View3;

        public UITextView readInfo;
        public static float viewScroll1Y = 0;
        public static float viewScroll2Y = 0;

        

        public void ViewDidLoad1()
        {
            base.ViewDidLoad();
            //var plist = NSUserDefaults.StandardUserDefaults;
            //plist.SetFloat(viewScroll1Y, "viewScroll1Y");
            //plist.SetFloat(viewScroll2Y, "viewScroll2Y");
            //View.BackgroundColor = UIColor.White;
            Title = "My Custom View Controller";
            
            var user = new UIViewController();
            user.View.BackgroundColor = UIColor.Purple;
            imageView = new UIImageView();
            imageView.Image = UIImage.FromBundle("Resources/pic5.png");
            //imageView.AccessibilityFrame = new CGRect(25, 500, 300, 150);
            //can't use picture via .frame or .AcessibilityFrame

            //imageView.TouchUpInside += (sender, e) => { ImageOnClick };

            Button2 = new UIButton(UIButtonType.System);
            Button2.Frame = new CGRect(25, 100, 300, 150);
            Button2.SetTitle("Click To Share", UIControlState.Normal);
            Button1 = new UIButton(UIButtonType.System);
            Button1.Frame = new CGRect(25, 200, 300, 150);
            Button1.SetTitle("Click to Read", UIControlState.Normal);

            var frame = new CGRect(10, 300, 300, 40);
            textView = new UITextView();
            textView.Frame = frame;
            textView.Text = "Begin your journey here! Share now!";
            textView.KeyboardType = UIKeyboardType.EmailAddress;
            textView.ReturnKeyType = UIReturnKeyType.Send;

            Buttonyourstoryscreen = new UIButton(UIButtonType.System);
            Buttonyourstoryscreen.Frame = new CGRect(25, 400, 300, 150);
            Buttonyourstoryscreen.SetTitle("Create your journal", UIControlState.Normal);

            Button1.AddTarget(Button1Click, UIControlEvent.TouchUpInside);
            Button2.AddTarget(Button2Click, UIControlEvent.TouchUpInside);
            Buttonyourstoryscreen.AddTarget(ButtonyourstoryscreenClick, UIControlEvent.TouchUpInside);

            //View.LargeContentImage = imageView;

            var ButtonShare = new UIButton(UIButtonType.RoundedRect)
            {
                Frame = UIScreen.MainScreen.Bounds,
                BackgroundColor = UIColor.Red
            };

            ButtonShare.TouchUpInside += (sender, e) => {
                String txt2 = "\n Your story: \n" + EmailReader.EmailFileRead.ReadText();
                var item = NSObject.FromObject(txt2);
                var activityItems = new NSObject[] { item };
                UIActivity[] applicationActivities = null;

                var activityController = new UIActivityViewController(activityItems, applicationActivities);

                PresentViewController(activityController, true, null);
            };

            Add(ButtonShare);
            View.Add(ButtonShare);
            View.AddSubview(textView);
            View.AddSubview(imageView);
            View.AddSubview(Button1);
            View.AddSubview(Button2);
            View.AddSubview(Buttonyourstoryscreen);
            //EmailFileRead.DeleteFileAfterMonths();
            
        }

        void Button1Click(object sender, EventArgs eventArgs)
        {
            //UIViewController viewController2 = this.Storyboard.InstantiateViewController("ViewController2");
            //if (viewController2 != null)
            //    this.NavigationController.PushViewController(viewController2,false);

            UIViewController view2 = new ViewController2();
           NavigationController.PushViewController(view2, true);
        }

        void ButtonyourstoryscreenClick(object sender, EventArgs eventArgs)
        {
           // ViewController3 view3 = new ViewController3();
           // NavigationController.PushViewController(view3, false);
        }

        private void ButtonyourstoryscreenUploadClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = new UITextView();
            editTextWrite = new UITextField();

            String text = editTextWrite.Text;
            EmailFileRead.WriteText(text);
            String totalText = EmailFileRead.ReadText();
            textViewWrite.Frame = new CGRect(25, 25, 300, 150);
            textViewWrite.Text = totalText;
            editTextWrite.Frame = new CGRect(25, 25, 300, 150);
            editTextWrite.Text = String.Empty;
        }

        private void ButtonDeleteClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = new UITextView();
            editTextWrite = new UITextField();
            textViewWrite.Frame = new CGRect(25, 25, 300, 150);
            editTextWrite.Frame = new CGRect(25, 25, 300, 150);
            EmailFileRead.DeleteText();
            textViewWrite.Text = String.Empty;
        }

        private void Button2Click(object sender, EventArgs eventArgs)
        {
            var txt = EmailFileRead.ReadText("Resources/Reflections2.text");
            String txt2 = "\n Your story: \n" + EmailReader.EmailFileRead.ReadText();

            /* SHARE HERE await Share.RequestAsync(new ShareFileRequest)
            Intent intentsend = new Intent();
            intentsend.SetAction(Intent.ActionSend);
            intentsend.PutExtra(Intent.ExtraText, txt + txt2);
            intentsend.SetType("text/plain");
            StartActivity(intentsend);
			*/
        }
    }
}

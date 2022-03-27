using System;
using CoreGraphics;
using EmailReader;
using UIKit;

namespace phillBookApp
{
    public partial class ViewController3 : UIViewController
    {
        public ViewController3() : base("ViewController3", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ViewDidLoad1();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public UITextField editText;
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
        public UIButton ButtonDelete1Line;

        public UIImage imageView;
        public UIView View1;
        public UIView View2;
        public UIView View3;
        int togglePicture;

        public UITextView readInfo;
        UILabel label1;

      

        public void ViewDidLoad1()
        {
            

            View.BackgroundColor = UIColor.White;
            Title = "My Custom View Controller";

            var user = new UIViewController();
            user.View.BackgroundColor = UIColor.Purple;

            textViewWrite = new UITextView();
            editTextWrite = new UITextField();
            Buttonbackyourstory = new UIButton(UIButtonType.System);
            ButtonyourstoryscreenUpload = new UIButton(UIButtonType.System);
            ButtonDelete = new UIButton(UIButtonType.System);
            var frame = new CGRect(10, 10, 300, 40);

            Buttonbackyourstory.Frame = new CGRect(25, 25, 300, 150);
            Buttonbackyourstory.SetTitle("Back", UIControlState.Normal);

            ButtonyourstoryscreenUpload.Frame = new CGRect(25, 25, 300, 150);
            ButtonyourstoryscreenUpload.SetTitle("Submit", UIControlState.Normal);
            ButtonDelete.Frame = new CGRect(25, 25, 300, 150);
            ButtonDelete.SetTitle("Start Over", UIControlState.Normal);

            ButtonDelete1Line = new UIButton(UIButtonType.System);
            ButtonDelete1Line.Frame = new CGRect(25, 25, 300, 150);
            ButtonDelete1Line.SetTitle("Delete Previous line", UIControlState.Normal);

            UIScrollView scrollView = new UIScrollView();
            scrollView.Frame = frame;
            View.Add(scrollView);

            editTextWrite.Text = "Enter your email to begin your story!";
            editTextWrite.KeyboardType = UIKeyboardType.EmailAddress;
            editTextWrite.ReturnKeyType = UIReturnKeyType.Send;
            scrollView.Add(booktextView);

            Buttonbackyourstory.AddTarget(ButtonbackyourstoryscreenClick, UIControlEvent.TouchUpInside);
            ButtonyourstoryscreenUpload.AddTarget(ButtonyourstoryscreenUploadClick, UIControlEvent.TouchUpInside);
            ButtonDelete.AddTarget(ButtonDeleteClick, UIControlEvent.TouchUpInside);
            ButtonDelete1Line.AddTarget(ButtonDelete1LineClick, UIControlEvent.TouchUpInside);

            UIScrollView scrollView2 = new UIScrollView();
            scrollView2.Frame = frame;
            View.Add(scrollView2);

            textViewWrite.Frame = new CGRect(25, 25, 300, 150);
            textViewWrite.Text = "";
            textViewWrite.Text = EmailFileRead.ReadText();
            scrollView2.Add(textViewWrite);
            //scroll to bottom
            View.AddSubview(Buttonbackyourstory);
            View.AddSubview(ButtonyourstoryscreenUpload);
            View.AddSubview(ButtonDelete1Line);
            View.AddSubview(ButtonDelete);
        }

        private void ButtonyourstoryscreenUploadClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = new UITextView();
            editTextWrite = new UITextField();
            if (EmailFileRead.FileSizeWarning())
            {
                var Confirm = new UIAlertView("Confirmation", "File is too big, please send", null, "Cancel", "Yes");
                Confirm.Show();
                Confirm.Clicked += (object senders, UIButtonEventArgs es) =>
                {
                    if (es.ButtonIndex == 0)
                    {
                        //Do nothing
                    }
                    else
                    {
                        //Do nothing
                    }
                };

            }
            else
            {
                String text = editTextWrite.Text;
                if (editTextWrite.Text == String.Empty)
                    text = "";
                EmailFileRead.WriteText(text);
                String totalText = EmailFileRead.ReadText();
                textViewWrite.Frame = new CGRect(25, 25, 300, 150);
                textViewWrite.Text = totalText;
                editTextWrite.Frame = new CGRect(25, 25, 300, 150);
                editTextWrite.Text = String.Empty;
            }
        }

        private void ButtonDeleteClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = new UITextView();
            editTextWrite = new UITextField();
            textViewWrite.Frame = new CGRect(25, 25, 300, 150);
            editTextWrite.Frame = new CGRect(25, 25, 300, 150);
            var Confirm = new UIAlertView("Confirmation", "Are you Sure ", null, "Cancel", "Yes");
            Confirm.Show();
            Confirm.Clicked += (object senders, UIButtonEventArgs es) =>
            {
                if (es.ButtonIndex == 0)
                {
                    //Do nothing
                }
                else
                {
                    EmailFileRead.DeleteText();
                    textViewWrite.Text = String.Empty;
                }
                textViewWrite.Text = EmailFileRead.ReadText();
            };
        }

        private void ButtonDelete1LineClick(object sender, EventArgs eventArgs)
        {
            textViewWrite = new UITextView();
            editTextWrite = new UITextField();
            textViewWrite.Frame = new CGRect(25, 25, 300, 150);
            editTextWrite.Frame = new CGRect(25, 25, 300, 150);
            EmailFileRead.DeleteLastLine();
            EmailFileRead.DeleteLastLine();
            textViewWrite.Text = EmailFileRead.ReadText();
        }

        private void ButtonbackyourstoryscreenClick(object sender, EventArgs eventArgs)
        {
           // ViewController view1 = new ViewController();
           // NavigationController.PushViewController(view1, false);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


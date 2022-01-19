using System;

public class ControlDialog
{
    private static ControlDialog instance;

    public static ControlDialog GetInstance() => instance ??= new ControlDialog();
    
    public event EventHandler<TextChangedArgs> TextChanged;

    public void ChangeText(string key) {
        TextChanged?.Invoke(this, new TextChangedArgs { key = key });
    }
}

public class TextChangedArgs : EventArgs {
    public string key { get; set; }
}
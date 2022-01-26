using System;

public class ControlSpeech
{
    private static ControlSpeech instance;

    public static ControlSpeech GetInstance() => instance ??= new ControlSpeech();
    
    public event Action TextChanged;

    public void ChangeText() {
        TextChanged?.Invoke();
    }
}
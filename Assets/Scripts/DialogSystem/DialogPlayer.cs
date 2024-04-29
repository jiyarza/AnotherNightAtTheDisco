public class DialogPlayer
{
    private Dialog dialog;
    private int index;

    public int Index => index;

    public void Reset()
    {
        index = 0;
    }

    public DialogEntry Next
    {
        get
        {
            if (index >= 0 && index < dialog.Entries.Length)
            {
                return dialog.Entries[index++];
            }
            else
            {
                return null;
            }
        }
    }

    public DialogPlayer(Dialog dialog)
    {
        this.dialog = dialog;
        index = 0;
    }


}

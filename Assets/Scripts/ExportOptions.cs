using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ExportOptions : MonoBehaviour
{
    public Text exportConfirmationTextBox;
    private string filePath;

    private void WriteOptions(StreamWriter writer)
    {
        for (int i = 0; i < RecordOptions.choiceNames.Count; i++)
        {
            if (i == 0)
            {
                writer.WriteLine($"Started at {RecordOptions.timeOfDay[i]}");
            }
            else
            {
                writer.WriteLine($"\n{RecordOptions.choiceNames[i]}\n{RecordOptions.timeOfDay[i]} after {RecordOptions.timeTaken[i]}");
            }
        }
    }

    private void WriteToFile(string filePath)
    {
        using StreamWriter writer = new(filePath);
        WriteOptions(writer);
    }

    public void ExportAsTxt()
    {
        string fileName = $"NHS AR Training App - {DateTime.Now:yyyy-MM-dd HH-mm-ss}.txt";

        if (Application.platform == RuntimePlatform.Android)
        {
            WriteToFile(Path.Combine("/storage/emulated/0/Download", fileName));
            exportConfirmationTextBox.text = $"Exported to device downloads folder!";
            return;
        }

        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", fileName);
            WriteToFile(filePath);
            exportConfirmationTextBox.text = $"Exported to:\n{filePath}";
            return;
        }
        
        // Will run if on ios
        filePath = Path.Combine(Application.temporaryCachePath, fileName);

        WriteToFile(filePath);

        new NativeShare().AddFile(filePath)
            .Share();

        exportConfirmationTextBox.text = $"File Exported!";
    }
}

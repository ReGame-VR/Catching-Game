using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadWriteCSV;
using System.IO;

/// <summary>
/// Writes a line of data after every trial, giving information on the trial.
/// </summary>
public class DataHandler : MonoBehaviour
{

    // stores the data for writing to file at end of task
    List<TrialData> trialData = new List<TrialData>();

    private string pid = GlobalControl.Instance.participantID;
    private string tryNum = GlobalControl.Instance.tryNumber.ToString();

    /// <summary>
    /// Write all data to a file
    /// </summary>
    void OnDisable()
    {
        WriteTrialFile();
    }

    // Records trial data into the data list
    public void recordTrial(float score)
    {
        trialData.Add(new TrialData(score));
    }

    /// <summary>
    /// A class that stores info on each trial relevant to data recording. Every field is
    /// public readonly, so can always be accessed, but can only be assigned once in the
    /// constructor.
    /// </summary>
    class TrialData
    {
        public readonly float score;

        public TrialData(float score)
        {
            this.score = score;
        }
    }

    /// <summary>
    /// Writes the Trial File to a CSV
    /// </summary>
    private void WriteTrialFile()
    {

        // Write all entries in data list to file
        Directory.CreateDirectory(@"Data/" + pid);
        using (CsvFileWriter writer = new CsvFileWriter(@"Data/" + pid + "/" + pid + "Try" + tryNum + ".csv"))
        {
            Debug.Log("Writing trial data to file");

            // write header
            CsvRow header = new CsvRow();
            header.Add("Participant ID");


            writer.WriteRow(header);

            // write each line of data
            foreach (TrialData d in trialData)
            {
                CsvRow row = new CsvRow();

                row.Add(pid);

                writer.WriteRow(row);
            }
        }
    }
}

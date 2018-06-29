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
    List<ContinuousData> continuousData = new List<ContinuousData>();
    List<ExplorationData> explorationData = new List<ExplorationData>();

    private string pid = GlobalControl.Instance.participantID;
    private string attemptNum = GlobalControl.Instance.attemptNumber;

    /// <summary>
    /// Write all data to a file
    /// </summary>
    void OnDisable()
    {
        WriteTrialFile();
        WriteContinuousFile();
        WriteExplorationFile();
    }

    // Records trial data into the data list
    public void recordTrial(float time, int trialNum, float score, float timeSinceSpawned,
            bool caught, Vector2 CoP, GlobalControl.Difficulty spawnDif, GlobalControl.Difficulty userSizeDif,
            GlobalControl.Difficulty fallSpeedDif, GlobalControl.Difficulty userSensitivityDif,
            GlobalControl.Difficulty fruitSizeDif, GlobalControl.Difficulty spawnFrequencyDif)
    {
        trialData.Add(new TrialData(time, trialNum, score, timeSinceSpawned, caught, CoP, spawnDif,
            userSizeDif, fallSpeedDif, userSensitivityDif, fruitSizeDif, spawnFrequencyDif));
    }
    // Records continuous data to list
    public void recordContinuous(float time, Vector2 CoP)
    {
        continuousData.Add(new ContinuousData(time, CoP));
    }
    // Records exploration data to list
    public void recordExploration(float time, Vector2 location)
    {
        explorationData.Add(new ExplorationData(time, location));
    }

    /// <summary>
    /// A class that stores info on each trial relevant to data recording. Every field is
    /// public readonly, so can always be accessed, but can only be assigned once in the
    /// constructor.
    /// </summary>
    class TrialData
    {
        public readonly float time;
        public readonly int trialNum;
        public readonly float score;
        public readonly float timeSinceSpawned;
        public readonly bool caught;
        public readonly Vector2 CoP;
        public readonly GlobalControl.Difficulty spawnDif; // difficulty of spawn location
        public readonly GlobalControl.Difficulty userSizeDif; // difficulty of user size
        public readonly GlobalControl.Difficulty fallSpeedDif; // difficulty of fall speed
        public readonly GlobalControl.Difficulty userSensitivityDif; // difficulty of user sensitivity
        public readonly GlobalControl.Difficulty fruitSizeDif; // difficulty of fruit size
        public readonly GlobalControl.Difficulty spawnFrequencyDif; // difficulty of spawn frequency

        public TrialData(float time, int trialNum, float score, float timeSinceSpawned,
            bool caught, Vector2 CoP, GlobalControl.Difficulty spawnDif, GlobalControl.Difficulty userSizeDif,
            GlobalControl.Difficulty fallSpeedDif, GlobalControl.Difficulty userSensitivityDif,
            GlobalControl.Difficulty fruitSizeDif, GlobalControl.Difficulty spawnFrequencyDif)
        {
            this.time = time;
            this.trialNum = trialNum;
            this.score = score;
            this.timeSinceSpawned = timeSinceSpawned;
            this.caught = caught;
            this.CoP = CoP;
            this.spawnDif = spawnDif;
            this.userSizeDif = userSizeDif;
            this.fallSpeedDif = fallSpeedDif;
            this.userSensitivityDif = userSensitivityDif;
            this.fruitSizeDif = fruitSizeDif;
            this.spawnFrequencyDif = spawnFrequencyDif;
        }
    }

    // Class that stores continuous data like CoP
    class ContinuousData
    {
        public readonly float time;
        public readonly Vector2 CoP;

        public ContinuousData(float time, Vector2 CoP)
        {
            this.time = time;
            this.CoP = CoP;
        }
    }

    // Class that stores exploration data like obstacle location
    class ExplorationData
    {
        public readonly float time;
        public readonly Vector2 location;

        public ExplorationData(float time, Vector2 location)
        {
            this.time = time;
            this.location = location;
        }
    }

    /// <summary>
    /// Writes the Trial File to a CSV
    /// </summary>
    private void WriteTrialFile()
    {

        // Write all entries in data list to file
        Directory.CreateDirectory(@"Data/" + pid);
        using (CsvFileWriter writer = new CsvFileWriter(@"Data/" + pid + "/" + pid + "TrialAttempt" + attemptNum + ".csv"))
        {
            Debug.Log("Writing trial data to file");

            // write header
            CsvRow header = new CsvRow();
            header.Add("Time");
            header.Add("Trial Number");
            header.Add("Score");
            header.Add("Time Fruit Spent Falling");
            header.Add("Caught fruit?");
            header.Add("COP X");
            header.Add("COP Y");
            header.Add("Spawn Location Difficulty");
            header.Add("User Size Difficulty");
            header.Add("Fall Speed Difficulty");
            header.Add("User Sensitivity Difficulty");
            header.Add("Fruit Size Difficulty");
            header.Add("Spawn Frequency Difficulty");
            header.Add("Exploration Mode");

            writer.WriteRow(header);

            // write each line of data
            foreach (TrialData d in trialData)
            {
                CsvRow row = new CsvRow();

                row.Add(d.time.ToString());
                row.Add(d.trialNum.ToString());
                row.Add(d.score.ToString());
                row.Add(d.timeSinceSpawned.ToString());
                if (d.caught)
                {
                    row.Add("YES");
                }
                else
                {
                    row.Add("NO");
                }
                row.Add(d.CoP.x.ToString());
                row.Add(d.CoP.y.ToString());
                row.Add(GlobalControl.Instance.DifficultyToString(d.spawnDif));
                row.Add(GlobalControl.Instance.DifficultyToString(d.userSizeDif));
                row.Add(GlobalControl.Instance.DifficultyToString(d.fallSpeedDif));
                row.Add(GlobalControl.Instance.DifficultyToString(d.userSensitivityDif));
                row.Add(GlobalControl.Instance.DifficultyToString(d.fruitSizeDif));
                row.Add(GlobalControl.Instance.DifficultyToString(d.spawnFrequencyDif));
                if (GlobalControl.Instance.explorationMode == GlobalControl.ExplorationMode.NONE)
                {
                    row.Add("NONE");
                }
                else
                {
                    row.Add("FORCED");
                }

                writer.WriteRow(row);
            }
        }
    }

    /// <summary>
    /// Writes the Continuous File to a CSV
    /// </summary>
    private void WriteContinuousFile()
    {

        // Write all entries in data list to file
        Directory.CreateDirectory(@"Data/" + pid);
        using (CsvFileWriter writer = new CsvFileWriter(@"Data/" + pid + "/" + pid + "ContinuousAttempt" + attemptNum + ".csv"))
        {
            Debug.Log("Writing continuous data to file");

            // write header
            CsvRow header = new CsvRow();
            header.Add("Time");
            header.Add("COP X");
            header.Add("COP Y");

            writer.WriteRow(header);

            // write each line of data
            foreach (ContinuousData d in continuousData)
            {
                CsvRow row = new CsvRow();

                row.Add(d.time.ToString());
                row.Add(d.CoP.x.ToString());
                row.Add(d.CoP.y.ToString());

                writer.WriteRow(row);
            }
        }
    }

    /// <summary>
    /// Writes the Exploration File to a CSV
    /// </summary>
    private void WriteExplorationFile()
    {

        // Write all entries in data list to file
        Directory.CreateDirectory(@"Data/" + pid);
        using (CsvFileWriter writer = new CsvFileWriter(@"Data/" + pid + "/" + pid + "ExplorationAttempt" + attemptNum + ".csv"))
        {
            Debug.Log("Writing exploration data to file");

            // write header
            CsvRow header = new CsvRow();
            header.Add("Time Obstacle Spawned");
            header.Add("Obstacle Location X");
            header.Add("Obstacle Location Y");

            writer.WriteRow(header);

            // write each line of data
            foreach (ExplorationData d in explorationData)
            {
                CsvRow row = new CsvRow();

                row.Add(d.time.ToString());
                row.Add(d.location.x.ToString());
                row.Add(d.location.y.ToString());

                writer.WriteRow(row);
            }
        }
    }
}

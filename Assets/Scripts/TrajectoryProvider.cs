using System;
using System.IO;
using UnityEngine;

public class TrajectoryProvider
{
    private JsonVector positions;
    private const string path = "Assets/Resources/path.json";

    public TrajectoryProvider()
    {
        StreamReader reader = new StreamReader(path);  //Read the text from directly from the test file
        var text = reader.ReadToEnd();

        positions = JsonUtility.FromJson<JsonVector>(text);

        reader.Close();
    }

    public Vector3 GetPosInTime(int i)
    {
        i = Mathf.Min(i, positions.x.Length - 1);
        return new Vector3(positions.x[i], positions.y[i], positions.z[i]);
    }

    [Serializable]
    private struct JsonVector
    {
        public float[] x;
        public float[] y;
        public float[] z;
    }
}

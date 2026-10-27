using System.Net.NetworkInformation;

public static class NeuralMath
{
    public static float[] MultiplyMatrixVector(float[,] weights, float[] inputs, float[] biases)
    {
        int nOutputs = weights.GetLength(0);
        int nInputs = weights.GetLength(1);

        if (inputs.Length != nInputs)
        {
            throw new System.ArgumentException("Количество входов не совпадает с количеством столбцов матрицы весов.");
        }

        float[] result = new float[nOutputs];

        for (int i = 0; i < nOutputs; i++)
        {
            float sum = biases[i];
            for (int j = 0; j < nInputs; j++)
            {
                sum += weights[i, j] * inputs[j];
            }
            result[i] = sum;
        }

        return result;
    }

    public static float[,] MultiplyMatrices(float[,] A, float[,] B)
    {
        int rowsA = A.GetLength(0);
        int colsA = A.GetLength(1);
        int rowsB = B.GetLength(0);
        int colsB = B.GetLength(1);

        if (colsA != rowsB)
        {
            throw new System.ArgumentException(
                $"Несовместимые размеры матриц: A={rowsA}×{colsA}, B={rowsB}×{colsB}. " +
                $"Для умножения нужно, чтобы colsA == rowsB."
            );
        }

        float[,] C = new float[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int k = 0; k < colsB; k++)
            {
                float sum = 0f;
                for (int j = 0; j < colsA; j++)
                {
                    sum += A[i, j] * B[j, k];
                }
                C[i, k] = sum;
            }
        }

        return C;
    }

    public static float ReLu(float value)
    {
        return value > 0 ? value : 0f;
    }

    public static float EvaluateLoss(float trueValue, float output)
    {
        return (trueValue - output) * (trueValue - output);
    }
}

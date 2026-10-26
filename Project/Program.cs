public class Program
{
    public static void Main()
    {
        //Random rand = new Random();

        //var neuralNetwork = new NeuralNetwork();

        //for (int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine("00-----------------------00");
        //    neuralNetwork.TrainLinearModel
        //    (
        //        rand.Next(0, 100),
        //        rand.Next(0, 100),
        //        0.0001f,
        //        1000,
        //        rand.Next(0, 500)
        //    );
        //}

        NeuralNetwork neuralNetwork = new NeuralNetwork(2, 1, new NeuronLayer(3), new NeuronLayer(3));
    }
}

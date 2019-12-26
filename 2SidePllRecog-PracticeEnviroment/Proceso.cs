using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2SidePllRecog_PracticeEnviroment
{
    class Proceso
    {
        Random rnd = new Random();
        int n, numeroDeScrambles;
        string[] scrambles = new string[71] { "L2 B2 F2 R2 D' L2 B2 F2 R2", "L2 U F2 R2 B2 D' B2 R2 F2 U2 L2 U2",
                                            "R2 U' F2 L2 B2 D B2 L2 F2 U2 R2 U2", "R2 U' F2 L2 B2 D B2 L2 F2 U2 R2 U",
                                            "L2 U F2 R2 B2 D' B2 R2 F2 U2 L2 U", "L2 U F2 R2 B2 D' B2 R2 F2 U2 L2 U'",
                                            "R2 U' F2 L2 B2 D B2 L2 F2 U2 R2", "F2 U F2 U F2 U F2 U F2 U L' R U2 L R' U",
                                            "F2 U F2 U F2 U F2 U F2 U L' R U2 L R'", "R2 U' F2 L2 B2 D B2 L2 F2 U2 R2 U'",
                                            //10
                                            "L2 U F2 R2 B2 D' B2 R2 F2 U2 L2", "L2 R2 D' R2 D2 B2 D L2 U2 F2 U' L R F2 D2 L' R U2",
                                            "R2 D B2 D' F2 D B2 D' F2 R2", "R2 F2 D B2 D' F2 D B2 D' R2",
                                            "B2 L2 R2 U L2 U' F2 R2 U' B2 U R' B2 L2 R2 F2 R' U'", "B2 L2 R2 U L2 U' F2 R2 U' B2 U R' B2 L2 R2 F2 R' U2",
                                            "L2 D' B2 D B2 U' B2 U B2 L2 U2", "B2 D L2 D' L2 U L2 U' L2 B2 U' ",
                                            "B2 D L2 D' L2 U L2 U' L2 B2 U2", "L2 D' B2 D B2 U' B2 U B2 L2 U",
                                            //20
                                            "L2 R2 U' L2 D2 F2 D L2 U2 B2 U L R F2 U2 L R' U'", "R L' U2 B2 R L U' L2 B2 D2 B2 D' B2 R2 D2 L2",
                                            "L' R U2 B2 L' R' U R2 B2 D2 B2 D B2 L2 D2 R2", "L2 D' B2 D B2 U' B2 U B2 L2",
                                            "L2 D' B2 D B2 U' B2 U B2 L2 U'", "B2 D L2 D' L2 U L2 U' L2 B2 U",
                                            "B2 D L2 D' L2 U L2 U' L2 B2", "F2 D R2 U' R2 F2 D' L2 U L2 U",
                                            "F2 D R2 U' R2 F2 D' L2 U L2", "L2 D F2 D' B2 D R2 B2 U B2 D B F' R2 B F' U",
                                            //30
                                            "R2 F2 R2 F2 D' R2 D B2 U' B2 U L' R U2 L R' U", "R2 U' F2 U B2 U' F2 U B2 R2 U2",
                                            "R2 U B2 U' F2 U B2 U' F2 R2 U'", "R2 D' R2 F2 U' F2 D R2 B2 U L R' U2 L' R'",
                                            "L2 U' B2 U L2 B2 D L2 D' B2 U' L' R B2 L R' U2", "F2 L2 U B2 U' L2 B2 D' R2 F2 U' L R' U2 L R' U2",
                                            "L2 U' F2 R2 U' F2 D B2 F2 R2 D' L' R U2 L R' U2", "L2 U' F2 R2 U' F2 D B2 F2 R2 D' L' R U2 L R' U",
                                            "F2 L2 U B2 U' L2 B2 D' R2 F2 U' L R' U2 L R' U", "R2 D B2 D' F2 D B2 D' F2 R2 U2",
                                            //40
                                            "R2 F2 D B2 D' F2 D B2 D' R2 U2", "R2 F2 R2 F2 D' R2 D B2 U' B2 U L' R U2 L R' U2",
                                            "L2 D F2 D' B2 D R2 B2 U B2 D B F' R2 B F'", "L2 U' B2 U L2 B2 D L2 D' B2 U' L' R B2 L R' U",
                                            "R2 D' R2 F2 U' F2 D R2 B2 U L R' U2 L' R' U'", "L2 R2 U' L2 D2 F2 D L2 U2 B2 U L R F2 U2 L R'",
                                            "L2 R2 U' L2 D2 F2 D L2 U2 B2 U L R F2 U2 L R' U2", "F2 L2 U B2 U' L2 B2 D' R2 F2 U' L R' U2 L R'",
                                            "R2 D' R2 F2 U' F2 D R2 B2 U L R' U2 L' R' U", "L2 U' F2 R2 U' F2 D B2 F2 R2 D' L' R U2 L R' U'",
                                            //50
                                            "L2 U' B2 U L2 B2 D L2 D' B2 U' L' R B2 L R' U", "L2 R2 D' R2 D2 B2 D L2 U2 F2 U' L R F2 D2 L' R U'",
                                            "L2 R2 D' R2 D2 B2 D L2 U2 F2 U' L R F2 D2 L' R U", "L2 U' F2 R2 U' F2 D B2 F2 R2 D' L' R U2 L R'",
                                            "L2 D F2 D' B2 D R2 B2 U B2 D B F' R2 B F' U2", "F2 L2 U B2 U' L2 B2 D' R2 F2 U' L R' U2 L R' U'",
                                            "R2 F2 R2 F2 D' R2 D B2 U' B2 U L' R U2 L R'", "R2 U' F2 U B2 U' F2 U B2 R2",
                                            "L2 D' B2 U B2 L2 D F2 U' F2 U'", "R2 D B2 D' F2 D B2 D' F2 R2 U'",
                                            //60
                                            "F2 D R2 U' R2 F2 D' L2 U L2 U'", "L2 R2 D' R2 D2 B2 D L2 U2 F2 U' L R F2 D2 L' R",
                                            "L2 R2 U' L2 D2 F2 D L2 U2 B2 U L R F2 U2 L R' U", "F2 D2 B2 D' L2 B2 D B2 L2 D2 B2 L D L' F2 R U' R' U",
                                            "F2 D2 B2 D' L2 B2 D B2 L2 D2 B2 L D L' F2 R U' R'", "B2 L2 R2 U L2 U' F2 R2 U' B2 U R' B2 L2 R2 F2 R'",
                                            "B2 L2 R2 U L2 U' F2 R2 U' B2 U R' B2 L2 R2 F2 R' U", "L2 U' B2 U L2 B2 D L2 D' B2 U' L' R B2 L R'",
                                            "L2 D F2 D' B2 D R2 B2 U B2 D B F' R2 B F' U'", "R2 F2 R2 F2 D' R2 D B2 U' B2 U L' R U2 L R' U'",
                                            //70
                                            "R2 D' R2 F2 U' F2 D R2 B2 U L R' U2 L' R' U2"
                                            };

        string[] scramblesPorGenerar = new string[71];

        string[] rotaciones = new string[] { "x", "x'", "y", "y'", "z", "z'" };

        string[] movimientosFinales = new string[] { "d", "d'", "d2" };

        public void agregarScramble(int i)
        {
            scramblesPorGenerar[n] = scrambles[i-1];
            n++;
        }

        public void ingresarNumeroDeScrambles(int numero)
        {
            numeroDeScrambles = numero;
        }

        public string rotacionesAleatorias()
        {
            string r = "";
            string r1, r2;
            int rotacionAleatoria1 = rnd.Next(6);
            r1 = rotaciones[rotacionAleatoria1];
            string r1prima = "";
            if (r1.Length == 1)
            {
                r1prima = r1 + "'";
            }
            else if (r1.Length == 2)
            {
                r1prima = r1[0].ToString();
            }
            string[] rotacionesSobrantes = new string[4];
            int j = 0;
            for(int i = 0; i < 6; i++)
            {
                if (r1 == rotaciones[i] || r1prima==rotaciones[i])
                {
                    continue;
                }
                else
                {
                    rotacionesSobrantes[j] = rotaciones[i];
                    j++;
                }
            }
            int rotacionAleatoria2 = rnd.Next(4);
            r2 = rotacionesSobrantes[rotacionAleatoria2];
            r = r1 + " " + r2;
            return r;
        }

        public string scramblesGenerados()
        {
            string scrambles = "";

            if (scramblesPorGenerar[0] != null)
            {
                for (int i = 0; i < numeroDeScrambles; i++)
                {
                    int numeroAleatorio = rnd.Next(n);
                    int finalAleatorio = rnd.Next(3);
                    scrambles += i + 1 + "_ " + rotacionesAleatorias() + " " + scramblesPorGenerar[numeroAleatorio] + " " + movimientosFinales[finalAleatorio] + "\r\n\r\n";
                }
            }
            return scrambles;
        }
    }
}

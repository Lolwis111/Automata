using System.Linq;
using System.Drawing;
using AutomataGUI.Model;
using System.IO;

namespace AutomataGUI.LoadSave
{
    internal static class Export
    {
        public static void ExportAsPng(StateMachine automaton, string fileName)
        {
            float maxX = float.MinValue;
            float maxY = float.MinValue;
            float minX = float.MaxValue;
            float minY = float.MaxValue;

            foreach (Drawable drawable in automaton.Drawables)
            {
                PointF max = drawable.GetMaximum();
                PointF min = drawable.GetMinimum();

                if (min.X < minX)
                {
                    minX = min.X - 5;
                }

                if (min.Y < minY)
                {
                    minY = min.Y - 5;
                }

                if (max.X > maxX)
                {
                    maxX = max.X + 5;
                }

                if (max.Y > maxY)
                {
                    maxY = max.Y + 5;
                }
            }

            int width = (int)(maxX - minX) + 100;
            int height = (int)(maxY - minY) + 100;

            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.White);

                    foreach (Drawable drawable in automaton.Drawables)
                    {
                        drawable.Draw(graphics, -(int)minX, -(int)minY);
                    }

                    graphics.Flush();
                }

                bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }


        public static void ExportAsLatex(StateMachine automaton, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.WriteLine("\\documentclass{scrartcl}");
                writer.WriteLine("\\usepackage{tikz}");
                writer.WriteLine("\\usetikzlibrary{arrows,automata}");
                writer.WriteLine("\\usepackage{subfig}");
                writer.WriteLine("\\begin{document}");
                writer.WriteLine("\\begin{tikzpicture}[->.>=steahlth',shorten >=1pt,auto,node distance=2.0cm,semithick]"
	                             + "\\tikzstyle{every state}=[fill=white, draw=black, text=black]");

                float maxX = float.MinValue;
                float maxY = float.MinValue;
                float minX = float.MaxValue;
                float minY = float.MaxValue;

                foreach (State state in (from d in automaton.Drawables where (d is State) select d))
                {
                    if (state.Rectangle.X < minX)
                    {
                        minX = state.Rectangle.X - 5;
                    }

                    if (state.Rectangle.Y < minY)
                    {
                        minY = state.Rectangle.Y - 5;
                    }

                    if (state.Rectangle.X > maxX)
                    {
                        maxX = state.Rectangle.X + 5;
                    }

                    if (state.Rectangle.Y > maxY)
                    {
                        maxY = state.Rectangle.Y + 5;
                    }
                }

                //int width = (int)(maxX - minX) + 100;
                //int height = (int)(maxY - minY) + 100;

                // 1/max = x/coord coord/max

                foreach (State state in (from d in automaton.Drawables where (d is State) select d))
                {
                    float x = (10 * state.Center.X) / maxX;
                    float y = (10 * state.Center.Y) / maxY;
                    writer.WriteLine($"\\node[state] ({state.Id}) at ({x}, {y}) {{{state.Label}}};");
                }

                writer.WriteLine("\\path[->]");

                foreach (Transition trans in (from d in automaton.Drawables where (d is Transition) select d))
                {
                    if (trans.IsLoop)
                    {
                        writer.WriteLine($"({trans.StartPoint.Id}) edge [loop above,sloped] node {{{trans.Label}}} ({trans.EndPoint.Id})");
                    }
                    else
                    {
                        writer.WriteLine($"({trans.StartPoint.Id}) edge [sloped] node {{{trans.Label}}} ({trans.EndPoint.Id})");
                    }
                }

                writer.WriteLine(";");

                writer.WriteLine("\\end{tikzpicture}");
                writer.WriteLine("\\end{document}");
            }
        }

        /*
         * \documentclass{scrartcl}

\usepackage{tikz}
\usetikzlibrary{arrows,automata}

\usepackage{subfig}

\begin{document}

\section{Aufgabe 13}
\subsection{a)}

	\begin{tikzpicture}[->.>=steahlth',shorten >=1pt,auto,node distance=2.0cm,semithick]
	    \tikzstyle{every state}=[fill=white,draw=black,text=black]

   		\node[state,initial]    (A)                 {$q_0$};

   		\node[state,accepting]  (B)[right of=A]     {$q_1$};

   		\path[->]

	    (A) edge [loop above]   node {a} (A)
	        edge [bend left]    node {b} (B)
	    (B) edge [bend left]    node {a} (A)
	        edge [loop above]   node {b} (B);

	\end{tikzpicture}


	\begin{tikzpicture}[->.>=steahlth',shorten >=1pt,auto,node distance=2.0cm,semithick]
   		\tikzstyle{every state}=[fill=white,draw=black,text=black]

   		\node[state,initial]    (A)                 {$q_0$};

	    \node[state,accepting]  (B)[right of=A]     {$q_1$};

	    \path[->]

   		(A) edge [loop above]   node {b} (A)
	        edge [bend left]    node {a} (B)
	    (B) edge [bend left]    node {a} (A)
	        edge [loop above]   node {b} (B);
	\end{tikzpicture}

\end{document}

         */
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//
// ⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⣼⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⣸⣿⣿⣷⣤⣴⣦⣀⣠⣶⡶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⢠⣄⡀⠀⣼⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠘⣿⣿⣿⣿⣿⣿⣿⡾⢛⠋⡛⠻⣿⣿⣿⣿⣧⣴⣶⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⢸⣿⣿⣿⣿⣽⡏⠰⡈⢆⢡⣷⢀⠻⣿⣿⣿⣿⣇⡀⢀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⢻⣿⣿⣿⣻⣿⠄⢣⠘⡄⢺⡏⢄⢣⡌⠻⣿⣿⣿⣿⣿⣿⣷⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣷⣶⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⣀⣸⣿⣿⣿⣿⣿⡏⢄⠣⢌⣹⠇⡌⣼⢇⠱⡈⠿⣿⣿⣿⡿⠿⠛⠛⠛⠛⠛⠛⠛⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠹⢿⣿⣿⣿⣷⣿⣿⣦⠑⣂⡿⠰⡐⡿⢈⠆⡑⢢⢙⡿⢉⠐⡠⠑⣈⠂⠥⠘⡀⢃⠰⠀⡌⠙⠯⣉⢩⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠈⠹⣿⣿⣿⣽⣿⣷⣜⠏⡰⢱⡟⡠⢊⠔⣡⡿⢁⠂⡡⠄⢡⠠⠌⢠⠁⠒⡈⠄⡡⢀⠃⠤⣹⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠈⣻⣿⣿⣿⣿⣿⣷⣤⠹⢇⠰⡁⢎⣾⠁⠂⡔⠠⠘⡀⢂⠌⠄⠌⠡⡐⢈⡐⠄⢊⣼⣿⣿⣿⣿⣿⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠙⠛⠛⢻⣿⣿⣯⣿⣿⣷⣌⠢⠑⢬⡇⠌⠡⠠⠑⢂⢁⢢⡈⠌⡐⠡⠠⢁⡐⠈⢼⣿⣿⣿⣿⡿⢁⢻⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠈⣻⣿⣿⣿⣿⣿⣧⣍⢾⠃⠌⢂⡁⢎⣶⣿⣯⣭⡘⠰⡡⢁⠂⠤⢉⠈⠿⣿⣿⠟⢀⠂⠄⠛⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⡙⢹⣿⣿⣿⣿⣿⣿⠈⠔⠂⢤⣿⣿⣿⣿⣿⣅⠀⠹⠄⡘⢀⢂⠡⠂⢄⠠⢈⠄⠊⠌⡐⢉⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⢰⡇⡇⣾⣿⣿⡿⣿⣿⣿⡈⠄⢃⠘⣿⣿⣿⣿⣿⣿⠀⢠⠃⠄⠃⠄⡂⢉⠄⢂⠡⢈⠌⡐⢈⠄⡘⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⣓⡘⠿⣿⢷⠙⠛⣻⠡⢈⠄⢊⡘⢿⢿⠿⠟⠃⢠⠞⣨⠐⡉⡐⢈⠤⠈⡄⢂⡁⢂⠌⠄⡂⠔⠘⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⣯⠱⢈⠐⠂⢾⣁⣂⣽⣆⠂⣌⣼⠇⠠⢉⠐⡀⠉⠤⢈⠳⠇⡐⠠⢁⠂⡡⠐⡠⠐⠂⠌⡐⠐⡨⠐⠸⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣇⠂⠌⣁⠂⡉⢹⣟⣿⣻⡯⠁⠌⢂⡁⠢⢈⢁⠒⠠⠒⡀⠆⣁⠂⠡⠄⡑⠠⠑⣈⠐⡈⠔⠠⠑⢂⢹⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣧⠌⣀⠒⡈⡐⠻⣮⡷⠃⠌⢂⠡⠠⠑⣀⠊⠄⡑⠠⢁⠂⠤⢈⠁⠆⡐⠡⠌⣀⠂⠡⠌⢂⠡⢂⠘⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢳⣤⠒⠠⠐⠡⣀⠐⡈⠔⡈⠤⠑⡈⠄⠌⡐⢈⡁⢂⠡⠒⡈⠰⠈⢄⡁⠆⠠⠌⠡⣈⠐⡐⡈⠌⣻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢷⡈⠅⠒⡀⢂⠁⠆⠰⠀⡅⠂⠌⠒⡈⠄⠰⠈⢄⠡⠐⠡⠌⢠⠐⡈⢡⠈⠔⡀⠒⢠⠐⡈⣿⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠠⢁⠂⢿⡆⠌⡁⢺⠇⡁⢊⠐⣄⠉⠄⠃⡄⠊⠌⡐⠌⡀⠆⡁⢂⠌⡐⠠⠉⠄⢂⠁⣾⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠘⣧⠒⡈⠄⢶⢀⠡⡞⡐⠠⢁⣞⠂⢌⠘⢠⠐⣡⡬⠴⢒⠃⡐⡈⠄⢂⠌⠡⠘⡈⠄⢊⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠹⣧⠀⢀⣤⠾⢷⡐⡈⢼⡆⢸⡇⠡⢘⣼⢳⡿⣦⠈⣤⠿⢁⢂⠁⠆⡈⠔⠠⢁⠊⠄⡡⠡⢐⠈⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⢃⢹⡷⠋⢄⠂⠜⠹⢶⠾⢁⠚⢿⡴⠟⢡⣿⠓⠸⣿⠋⡐⠄⢂⠉⡐⡐⠨⠐⠡⡈⢄⡛⢁⠂⣸⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⢰⠀⡂⠿⠈⢄⡈⢂⡁⢂⠐⠂⡌⠠⠐⡈⠴⣿⢀⠡⠘⣆⠰⢈⠂⢡⠐⣀⠃⠡⢒⡼⠋⡐⠈⣴⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⡀⠆⡁⢂⠡⢂⠐⡠⠐⡈⠄⠃⡄⠡⢁⠂⢼⣿⠀⠂⡅⢂⡐⠂⠌⢤⣒⠠⠬⠓⡉⠄⢒⣠⡿⠛⢶⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠷⠶⠶⢧⠶⡶⢶⠶⡷⢶⠾⡶⢶⠷⡶⠾⠼⢿⣠⣁⣐⣠⣀⣉⣒⣰⣂⣦⣥⣖⣴⠮⠿⠳⠶⠾⠴⠿⠿⠿⠳⠶⣦⣀⠀⠀⠀⠀⠀⠀⡀⠂
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣦⣶⣼⡟⠃⠀⠀⠀⠀⠀⠃⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⠿⠀⠀⠀⠀⠀⠀⠀⠀

// Esta clase deberia de ayudar el formulario que parte el curp y corrige los simbolos que lee el escaner con los caracteres especiales
// segun yo va a ser más facil que con visual basic pero ya me esta doliendo mi cabeza, lo bueno que es bastante similar solo tengo que volver a recordar c

namespace SIPABE_DIFGRO_FAH
{
    // Al ser 'static', funciona exactamente igual que un Módulo en Access asi que segun yo ya la hicimos.
    // Podemos llamarla desde cualquier lugar con UtilidadesQR.NombreDeLaFuncion()
    public static class UtilidadesQR
    {
        public static string CorregirQR(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";

            // En C#, las letras pueden castearse directamente desde su valor entero (ChrW) y deje los comentarios anteriores para no olvidar de donde vengo 
            texto = texto.Replace((char)9524, 'Á'); // El codigo del caracter estaba mal y por eso no me jalo la segunda vez
            texto = texto.Replace((char)9556, 'É');
            texto = texto.Replace((char)9552, 'Í');
            texto = texto.Replace((char)203, 'Ó');
            texto = texto.Replace((char)9484, 'Ú'); // Olvide poner el acento en las letras de la "E" a la "U", tehee~~
            texto = texto.Replace((char)208, 'Ñ');
            texto = texto.Replace((char)9604, 'Ü');

            return texto;
            // Ya me rugen mis tripitas, deseo con todo mi corazon un monster
        }

        // Traducimos Variant a string, ya que en C# trabajamos fuertemente tipados.
        // Los parámetros opcionales se definen dándoles un valor por defecto.
        public static string ParseWord(string phrase, int wordNum, string delimiter = "|", bool removeLeadingDelimiters = false, bool ignoreDoubleDelimiters = false)
        {
            // Ahora este modulo llama al mas nuevo integrante de la familia para corregir el QR  
            // (Esperemos que Gwendo sea más amable en C#)
            phrase = CorregirQR(phrase);

            if (string.IsNullOrEmpty(phrase)) return null;

            if (wordNum == 0) return phrase;

            if (removeLeadingDelimiters)
            {
                // Limpiamos los delimitadores al inicio
                while (phrase.StartsWith(delimiter))
                {
                    phrase = phrase.Substring(delimiter.Length);
                }
            }

            // MAGIA DE C# \,,/(^_^)\,,/ : StringSplitOptions.RemoveEmptyEntries hace el trabajo del While de vb
            StringSplitOptions opcionesSplit = ignoreDoubleDelimiters ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;

            // Separamos la cadena en un arreglo o "array"(lease con el tono mas fresa/niña lomecan que te imagines) como dice Gwendo
            string[] varArray = phrase.Split(new string[] { delimiter }, opcionesSplit);

            string strResult = null;

            if (varArray.Length > 0)
            {
                if (wordNum > 0)
                {
                    wordNum = wordNum - 1; // Ajustamos de índice 1 (humano) a índice 0 ([recuerden que empieza con zero y termina con zet]programación)
                    if (wordNum < varArray.Length)
                    {
                        strResult = varArray[wordNum];
                    }
                }
                else // Si es negativo, cuenta de reversa (desde el final del arreglo)
                {
                    wordNum = varArray.Length + wordNum;
                    if (wordNum >= 0 && wordNum < varArray.Length)
                    {
                        strResult = varArray[wordNum];
                    }
                }
            }

            // Asi que basicamnete no va a cambiar el texto de la cadena original que se va a guardar en QRcurp... 
            // Saludos a Haroluchis y Gwendolyn mis niños hermosos (seguramente nunca van a leer esto de todas maneras, siento que mientras mas lo quiero menos me quieren ellos)
            return strResult;
        }
    }
}

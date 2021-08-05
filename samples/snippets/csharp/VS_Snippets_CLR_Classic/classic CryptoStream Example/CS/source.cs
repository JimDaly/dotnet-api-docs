using System;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography;

public class Sample
{
// <Snippet1>
private static void EncryptData(string inName, string outName, byte[] aesKey, byte[] aesIV)
 {
     //Create the file streams to handle the input and output files.
     FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
     FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
     fout.SetLength(0);

     //Create variables to help with read and write.
     byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
     long rdlen = 0;              //This is the total number of bytes written.
     long totlen = fin.Length;    //This is the total length of the input file.
     int len;                     //This is the number of bytes to be written at a time.

     Aes aes = Aes.Create();
     CryptoStream encStream = new CryptoStream(fout, aes.CreateEncryptor(aesKey, aesIV), CryptoStreamMode.Write);

     Console.WriteLine("Encrypting...");

     //Read from the input file, then encrypt and write to the output file.
     while(rdlen < totlen)
     {
         len = fin.Read(bin, 0, 100);
         encStream.Write(bin, 0, len);
         rdlen = rdlen + len;
         Console.WriteLine("{0} bytes processed", rdlen);
     }

     encStream.Close();
     fout.Close();
     fin.Close();
 }
   // </Snippet1>
}

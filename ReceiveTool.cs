using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class ReceiveTool {
    public static byte[] ReceiveData(Socket client)
    {
        int dataHaveReceived = 0;
        byte[] datasize = new byte[4];
        int onceReceived = client.Receive(datasize, 0, 4, SocketFlags.None);
        int size = BitConverter.ToInt32(datasize, 0)-4;//数据总长度减去头长度4
        int dataLeft = size;
        byte[] data = new byte[size];
        while(dataHaveReceived<size)
        {
            onceReceived = client.Receive(data, dataHaveReceived, dataLeft, SocketFlags.None);
            if(onceReceived==0)
            {
                data = null;
                break;
            }
            dataHaveReceived += onceReceived;
            dataLeft -= onceReceived;
        }
 
        return data;

    }
    public static float[] ByteToFloat(byte[] bytes)
    {
        byte[] buffer = new byte[4];
        int times = (int)((float)(bytes.Length / 4));
        float[] floats = new float[times];
        for(int i=0;i<times;i++)
        {
            Array.ConstrainedCopy(bytes, i * 4, buffer, 0, 4);
            floats[i]=BitConverter.ToSingle(buffer,0);
        }
        return floats;
    }
}

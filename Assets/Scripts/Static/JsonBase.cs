using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;
using System.Collections.Generic;

public class JsonBase{

	public static string m_strFixedPath = "";
	public static string m_strFixedName = "data";
	protected static string GetPath(string value){
		string strPath = Directory.GetCurrentDirectory();
		if (!value.Substring(0, 1).Equals("/"))
		{
			strPath += "/";
		}
		strPath += value;
		return strPath;
	}

	public static string JsonPathToTextJsonStream(string strFileName){
		//string strPath = GetPath(strFileName);
		string strPath = m_strFixedPath + strFileName;
		FileStream pFile = new FileStream (strPath, FileMode.Open);
		byte [] pBuffer = new byte[pFile.Length];
		pFile.Read (pBuffer, 0, pBuffer.Length);
		string strTmp = System.Text.Encoding.UTF8.GetString(pBuffer);
		if (pFile != null){
			pFile.Close();
		}
		return strTmp;
	}

	private JsonBase(){
		m_strFixedPath = string.Format("{0}/"+ m_strFixedName +"/", Directory.GetCurrentDirectory ());
	}

	public static bool SaveFile(string strFileName, string [] pContexts){
		bool isRet = false;
		string strPath = m_strFixedPath + strFileName;
		FileStream pFile = null;
		StreamWriter pWriter = null;
		do{
			pFile = File.Create(strPath);
			if (pFile == null){
				break;
			}
			pWriter = new StreamWriter(pFile);
			if (pWriter == null){
			break;
				}
			foreach(string pNode in pContexts){
				pWriter.WriteLine(pNode);
			}
			pWriter.Flush();
			isRet = true;
		}while(false);
		
		if (pFile != null) {
			pFile.Close();
		}
		System.GC.Collect ();
		return isRet;
	}


	protected virtual string ToJsonString(System.Object pObject){
		string strJson = "";
		if (pObject != null && !(pObject.GetType() is MonoBehaviour)){
			strJson = JsonMapper.ToJson(pObject);
		}
		return strJson;
	}
}

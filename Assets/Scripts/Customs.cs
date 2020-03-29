﻿using UnityEngine;
using UnityEngine.SceneManagement;


public static class Customs
{
	public static void ShowInterstitialAd()
    {
        if (!GameManager.Instance.isNoAds && GoogleMobileAd.IsInterstitialReady)
            GoogleMobileAd.ShowInterstitialAd();
    }

    public static string Android_Id()
    {
        string android_id = "editor";

        #if !UNITY_EDITOR
        AndroidJavaClass up = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject> ("currentActivity");
        AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject> ("getContentResolver");  
        AndroidJavaClass secure = new AndroidJavaClass ("android.provider.Settings$Secure");
        android_id = secure.CallStatic<string> ("getString", contentResolver, "android_id");
        #endif

        return android_id;
    }

    public static bool Int2Bool(int _Value)
    {
        return _Value != 0;
    }

    public static string Money(int _Count)
	{
		string strNum1 = string.Empty;
		string strNum2 = string.Empty;
		string strNum3 = string.Empty;

		string moneyStr = _Count.ToString("D");

		if (moneyStr.Length <= 3)
		{
			return moneyStr + "C";
		}
        
		if (moneyStr.Length > 3 && moneyStr.Length <= 6)
		{
			int num1 = Mathf.FloorToInt(_Count * 0.0001f);
			int num2 = _Count - num1 * 1000;

			if (num2 < 10)
				strNum2 = $"00{num2:D}";
			else if (num2 >= 10 && num2 < 100)
				strNum2 = $"0{num2:D}";
			else
				strNum2 = $"{num2:D}";

			strNum1 = num1.ToString("D");
			return $"{strNum1},{strNum2}C";
		}
        
		if (moneyStr.Length > 6 && moneyStr.Length <= 9)
		{
			int num1 = Mathf.FloorToInt(_Count * 0.0000001f);
			int num2 = Mathf.FloorToInt(_Count - num1 * 100);

			if (num2 < 10)
				strNum2 = $"00{num2:D}";
			else if (num2 >= 10 && num2 < 100)
				strNum2 = $"0{num2:D}";
			else
				strNum2 = $"{num2:D}";

			int num3 = _Count - num1 * 1000000 - num2 * 1000;

			if (num3 < 10)
				strNum3 = $"00{num3:D}";
			else if (num3 >= 10 && num3 < 100)
				strNum3 = $"0{num3:D}";
			else
				strNum3 = $"{num3:D}";

			strNum1 = num1.ToString("D");
			return strNum1 + "," + strNum2 + "," + strNum3 + "C";
		}
        
		return "";
	}
}
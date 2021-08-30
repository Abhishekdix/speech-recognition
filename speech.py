import speech_recognition as sr
import pyttsx3
import time









def SpeakText(command):

	engine.say(command)
	engine.runAndWait()



while(1):
    try:



        r = sr.Recognizer()
        with sr.Microphone() as source:
            r.adjust_for_ambient_noise(source, duration=0.7)
            audio = r.listen(source)
        engine = pyttsx3.init()
        voices = engine.getProperty("voices")
        engine.setProperty("voice", voices[1].id)
        newVoiceRate = 117
        engine.setProperty('rate', newVoiceRate)

        MyText = r.recognize_google(audio)
        MyText = MyText.lower()
        print(MyText)
        if "jarvis" in MyText or "ruhi" in MyText:
            MyText=MyText.replace("rui","")
            MyText = MyText.replace("jarvis", "")
            f = open("hel.txt", "w")
            f.write(MyText)
            f.close()
            SpeakText("    Changes made")



    except:
        SpeakText("    can you please repeat what you said ")

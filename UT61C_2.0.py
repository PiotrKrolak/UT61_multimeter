import serial
import time

ser=serial.Serial()
ser.port='COM5'
ser.baudrate=2400
ser.bytesize=serial.SEVENBITS
ser.parity=serial.PARITY_ODD
ser.stopbits=1
ser.timeout=1
ser.setDTR(True)
ser.setRTS(False)

ser.open()
time.sleep(1)

cyfry_ASCI = [48,49,50,51,52,53,54,55,56,57] ##przechowuje kod ASCI
cyfry = [0,1,2,3,4,5,6,7,8,9]##wartosci
zakres = [0, 32, 16]##zakres pomiarowy, 0 - *10^0, 32 - *10^3, 64 - *10^6
znaki = ['Ohm', 'kOhm', 'MOhm']

while(True):

    zmienna = ser.read(14)##miernik wysyla 14 bitow

    if zmienna[0] == 43:
        if zmienna[1] == 63:
            print('brak pomiaru')
        else :

            for i in range(10):
                if zmienna[1] == cyfry_ASCI[i]: ##pierwsza cyfra pomiaru
                    jeden = cyfry[i]
                    #print(cyfry[i], end='')
            for i in range(10):
                if zmienna[2] == cyfry_ASCI[i]: ##druga cyfra pomiaru
                    dwa = cyfry[i]
                    #print(cyfry[i], end='')
            for i in range(10):
                if zmienna[3] == cyfry_ASCI[i]: ##trzecia cyfra pomiaru
                    trzy = cyfry[i]
                    #print(cyfry[i], end='')
            for i in range(10):
                if zmienna[4] == cyfry_ASCI[i]: ##czwarta cyfra pomiaru
                    cztery = cyfry[i]
                    #print(cyfry[i])
            for i in range(10):
                if zmienna[6] == cyfry_ASCI[i]: ##miejsce kropki
                    kropka = cyfry[i]
            for i in range(3):
                if zmienna[9] == zakres[0]:
                    skrot = znaki[0]
                if zmienna[9] == zakres[1]:
                    skrot = znaki[1]
                if zmienna[9] == zakres[2]:
                    skrot = znaki[2]
            if kropka == 0:
                print('+',jeden,dwa,trzy,cztery,skrot)
            if kropka == 1:
                print('+',jeden,',',dwa,trzy,cztery,skrot)
            if kropka == 2:
                print('+',jeden,dwa,',',trzy,cztery,skrot)
            if kropka == 4:
                print('+',jeden,dwa,trzy,',',cztery,skrot)

    elif zmienna[0] == 45:
        print('brak pomiaru')

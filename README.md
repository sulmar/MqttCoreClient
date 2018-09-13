# Mosquitto 

## Szybka instalacja

1. Pobierz [archiwum](http://www.steves-internet-guide.com/wp-content/uploads/mos1.14.7z) i rozpakuj go do katalogu *c:\mosquitto*

2. Uruchom serwer
~~~ bash   
mosquitto.exe -v
~~~

3. Sprawdzenie
~~~ bash
netstat -a
~~~

Domyœlny port 1883

## Nadawca

~~~ bash
mosquitto_pub -h 10.0.75.1 -m "21" -t house/room1/temp1
~~~

## Odbiorca

~~~ bash
mosquitto_sub -h 10.0.75.1 -t house/#
~~~

## Klient C#

~~~ 
PM> Install-Package MQTTnet.AspNetCore
~~~


## Links

* Dobre praktyki
https://www.hivemq.com/blog/mqtt-essentials-part-5-mqtt-topics-best-practices
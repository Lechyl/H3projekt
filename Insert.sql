use LongigantenDB;

/*
insert into PostNr(byNavn) values ("test");


	insert into Kategorier(navn, parent_KategoriID) values
('Hvidevarer',default),
('Vaskemaskine',1),
('Lyd & Hi-Fi',default),
('Hovedtelefoner',3),
('TV & Billede',default),
('Fladsk�rms TV',5),
('Gaming',default),
('Gaming Laptop',7),
('PC-komponenter',7),
('Processor',9)

insert into Producent(producentNavn) values
('Intel'),
('AMD'),
('Lenovo'),
('Bosch'),
('Siemens'),
('Bose'),
('Apple'),
('JBL'),
('Samsung'),
('Asus')

insert into Leverandor(leverandorNavn,kontaktPerson,email,telefon) values
('Apple Inc','Anders k�ld',default,'+45 73 31 57 41'),
('Intel Corporation','Emerkel Tarkov','tarkov@intel.com','+45 41 65 43 12'),
('Elgiganten Erhverv',default,'erhverv@elgiganten.dk','+45 70 70 27 70'),
('Lenovo Group Ltd','Lisa Lu','ll@lenovo.com','+86 389 1750389'),
('Samsung Electronics','Lee Kwang soo','lks@samsungelectronics.com','+45 91 74 14 84')

insert into Produkter(produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID) values
('Intel Core i7-9700K processor','Funktioner
- 8 cores/8 threads, 3,6 GHz base, 4,9 GHz turbofrekvens (p� en enkelt kerne)
- 12 MB L3 cache
- LGA1151 fatning - kr�ver Intel 300-series chipset
- 95 W termal-design kraft
- Forbedret 14 nm lithography-proces
- Dual-channel DDR4 RAM underst�tter op til 2.666 MHz
- Klar til Intel Optane hukommelse
- DirectX 12 underst�ttelse
- Integreret Intel UHD Graphics 630
- Underst�tter 4K UHD output ved op til 60 Hz
- Bl�serk�ler ikke inkluderet',
2969,10,1,2
),
('AMD Ryzen 7 3700X processor','Byg en kraftfuld arbejdsstation eller en ultimativ gaming-computer med AMD Ryzen 7 3700X octa core processoren. Processoren har h�j frekvensr�kkevidde og ul�st clock-forst�rker, der giver dig den perfekte mulighed til yderligere overclocking med en brugertilpasset termisk l�sning.

Precision Boost Overdrive:Takket v�re Precision Boost teknologien kan processoren overclockes med en mere effektiv fordeling af arbejdsopgaverne og opn� en h�jere overordnet maks. frekvens.

Features:
- 8 kerner/16 tr�de
- 3,6 GHz basisfrekvens, 4,4 GHz turbofrekvens
- Ul�st clock-forst�rker
- 36 MB L2 + L3 cache
- AM4 fatning
- 65 W termisk designydelse
- Zen+ arkitektur med 7 nm FinFET litografiproces
- DDR4 RAM op til 3200 MHz underst�ttelse
- Inklusiv Wraith Prism bl�sek�ler m/ RGB LED',
2642,10,2,3
),
('Lenovo Ideapad L340 15,6* gaming-computer','Den b�rbare Lenovo Ideapad L340 gaming computer er en ideel crossover mellem en kraftfuld gaming computer og en b�rbar arbejdsstation. Den kan sagtens k�re high-end AAA-spil uden problemer og du vil stadigv�k v�re i stand til at fuldf�re dit seneste projekt.

Dual-mode drift
Skift til "Fast" mode for en f�rsteklasses pr�station eller til "Quiet" mode, som er optimeret til effektivt at k�re dine arbejdsopgaver uden at afk�lingsbl�serne skal k�re for alt st�rkt.

9. gen. effektivitet
Den b�rbare computer er drevet af den h�jt ydende Intel Core i5 quad core processor fra Coffee Lake familien og kan let k�re selv kr�vende spil. Processoren kan skifte til op til 4,1 GHz turbotilstand. Den er ledsaget af 8 GB hurtige DDR4 RAM.

Grafik
Med Nvidia GeForce GTX 1050 grafikkortet er forskellen p� station�r og b�rbar computer n�sten udvisket. Grafikkortet er udstyret med 3 GB dedikerede RAM, s� du kan nyde en fordybende gaming- og e-sportsoplevelse i Full HD 1080pp opl�sning og med h�j billedfrekvens.

Full HD sk�rm
Computerens 15,6� IPS LED sk�rm har krystalklar og detaljeret Full HD 1080p opl�sning. De smalle rammer maksimerer sk�rmens plads uden at skabe un�dvendige forstyrrelser. IPS-teknologien giver dybere kontraster, lysere farver og bredere synsvinkler.

Bl�lysfiltrering
Lenovo Vantage �jenbeskyttelsessoftwaren reducerer bl�lys output fra sk�rmen og reducerer dine �jnes belastning ved lange arbejdstimer.

Privatlivs webcam
Uanset om det g�lder gaming uden forstyrrelser eller arbejde med fortrolige materialer, s� forhindrer den fysiske webcam skodde uvedkommende fra at benytte dit kamera.

Batteri og opladning
Med sin store batterikapacitet kan den b�rbare computer tilbyde op til 9,5 timers brugstid. Og takket v�re den hurtige opladning kan den oplades til op til 80 % kapacitet p� bare 60 minutter og fuldkapacitet p� bare 120 minutter.

Lyd
Stereo h�jttalerne er forbedrede med Dolby Audio lydbehandling, der kan levere en tordnende akustik p� tv�rs af dit v�relse.

Dobbelt lagring
Det lynhurtige 256 GB SSD drev giver ekstra korte booting- og loadingtider, s� du ikke skal spilde tid p� at vente, mens et spil starter.

HDMI
HDMI outputtet kan forbindes til et HD TV eller en projektor, s� du kan vise billeder og video i Full HD 1080p opl�sning p� en st�rre sk�rm.

Forbindelser:
- 1x vendbar USB-C 3.0 port
- 2x USB 3.0 porte
- Gigabit LAN port
- Lynhurtig wi-fi-ac og Bluetooth 4.2
- 3,5 mm lyd mini-jack

Andre egenskaber
- Windows 10 Home 64-bit styresystem
- Webcam med 720p HD opl�sning
- Touchpad med multi-touch
- Bagbelyst tastatur med numerisk tastatur',
5999,8,3,4),
('Bosch Series 6 vaskemaskine','Bosch Series 6 vaskemaskinen kan klare al vasket�j, uanset hvor beskidt det er. F� friskt t�j efter hver vask.

8 kg kapacitet: Den gener�se kapacitet g�r h�nd i h�nd med stor fleksibilitet. Vask et par enkelte kl�der, eller tag hele ugens vask p� �n gang. Vask efter ferier, forl�nget weekender og andre begivenheder vil ikke l�ngere v�re et problem.

Programmer: Vaskemaskinen har en r�kke praktiske hverdagsprogrammer som for eksempel et specielt program til uld, sarte stoffer samt ekstra hurtigt 15 minutters program.

VarioPerfect: F� vasket�jet hurtigt klaret eller v�lg den den mest energieffektive l�sning. SpeedPerfect kan forkorte vaskecyklussen med op til 65%, mens ecoPerfect forbruger 50% mindre energi sammenlignet med standardprogrammer.

VarioDrum: Dit t�j er sikret den mest sk�nsomme behandling takket v�re tromlens unikke design.

EcoSilence Drive: Den b�rstel�se motor har 10-�rs garanti og sikrer en effektiv samt stilleg�ende drift.

Placering: Ved at tilf�je gummif�dder kan du �ge stabiliteten og samtidigt reducere lyden fra apparatet. Hvis du �nsker at placere din t�rretumbler ovenp� vaskemaskinen, kan du g�re dette ved at anvende et stablingss�t. Dette kr�ver dog, at b�de vaskemaskinen og t�rretumbleren har samme m�l. Derfor b�r du v�re godt orienteret om m�lene p� b�de din vaskemaskine og t�rretumbler, f�r du anvender denne l�sning.

Vedligeholdelse: Husk at din vaskemaskine har brug for regelm�ssig reng�ring af tromlen. Varme og fugtige milj�er kan gro mug, hvilket kan resultere i lugte, som ikke �nskes p� t�j. V�lg korrekt vaskemiddel og forst�rk reng�ringseffekten.

Energiklasse: Denne Bosch-vaskemaskine forbruger 30% mindre energi end kravet til den bedste energiklasse A+++. Derfor er den et fremragende valg for dig, som er milj�bevidst og �nsker en vaskemaskine, som er ekstremt milj�venlig og �konomisk i drift.

Fandt du ikke lige den Bosch vaskemaskine, du ledte efter? Se hele vores udvalg af Bosch vaskemaskiner her.',
2899,2,4,3),
('Siemens IQ700 vaskemaskine','Siemens IQ700 vaskemaskinen har fleksibel kapacitet, SpeedPerfect-funktion samt 11 praktiske programmer, som giver t�jet sk�nsom behandling.

8 kg kapacitet: Den gener�se kapacitet giver stor fleksibilitet. Vask enkelte stykker t�j hurtigt eller vask vasket�jet fra hele ugen p� �n gang. St�rre m�ngder vasket�j fra ferier, forl�nget weekender og lignende begivenheder vil ikke l�ngere v�re noget problem.

iQdrive: Den holdbare b�rstel�se motor har 10 �rs garanti samt stilleg�ende og energieffektiv drift.

SpeedPerfect: SpeedPerfect-funktionen identificerer automatisk muligheder for at spare tid og energiforbrug p� hver vaskecyklusen. Derfor kan du du forkorte vaskecyklussen med op til 65% i tid.

LED-display: Oplev enkel betjening takket v�re det brugervenlig LED-display, der viser resterende tid og programinformation.

WaveDrum: Bliv kvit med bekymringer for, om t�jet sidder fast i tromlen. Den unikke kombination af dybe og lave kanter sikrer, at t�jet vaskes p� en effektiv, men sk�nsom m�de.

AntiVibration-panel: Panelet sikrer h�j stabilitet, som bidrager til den stilleg�ende drift p� kun 48 dB.

WaterPerfect Plus: Det avanceret sensorsystem hj�lper til at spare vandforbrug i hver vask. Sensoren justerer automatisk vandm�ngden efter hver t�jm�ngde. Funktionen hj�lper derfor til at spare p� udgifter uden at g� p� kompromis med vaskeresultaterne.

Placering: Ved at tilf�je gummif�dder kan du �ge stabiliteten og samtidigt reducere lyden fra apparatet. Hvis du �nsker at placere vaskemaskinen ovenp� din t�rretumbler, kan du g�re dette ved at anvende et stablingss�t. Dette kr�ver dog, at b�de vaskemaskinen og t�rretumbleren har samme m�l. Derfor b�r du v�re godt orienteret om m�lene p� b�de din vaskemaskine og t�rretumbler, f�r du anvender denne pladsbesparende l�sning.

Vedligeholdelse: Husk at din vaskemaskine har brug for regelm�ssig reng�ring af tromlen. Varme og fugtige milj�er kan gro mug, hvilket kan resultere i lugte, som ikke �nskes p� t�j. Indersiden af tromlen kan desinficeres ved at k�re et program ved h�j temperatur (gerne 85�C-90�C) med en tom vaskemaskine. V�lg det rigtige vaskemiddel og f� den mest optimale reng�ringseffekt.

Energiklasse: Denne vaskemaskine fra Siemens forbruger 30% mindre energi end kravet for energiklasse A+++. Perfekt til dig, det �nsker en ekstremt energieffektiv og �konomisk l�sning.',
5999,2,5,3),
('Bose QuietComfort 35 QC35 II tr�dl�se hovedtelefoner','De tr�dl�se Bose QuietComfort hovedtelefoner II kommer med indbygget Google Assistant, der giver dig fuld kontrol over din musik, dine opkald og daglige opgaver via din stemme. Samtidig leverer de en f�rsteklasses lydoplevelse takket v�re blandt andet noise-cancelling-teknologien, der udelukker lyden fra dine omgivelser. Den tr�dl�se Bluetooth-forbindelse med hurtig NFC-parring lader dig bruge hovedtelefonerne uden besv�r med ledninger, og den tr�dl�se forbindelse g�r ikke p� kompromis med lydkvaliteten. Takket v�re den ekstra lange batteritid p� op til 20 timer kan du bruge hovedtelefonerne i flere dage uden opladning. Og designet giver langvarig komfort takket v�re sine f�rsteklasses materialer og robuste konstruktion, der kan foldes, s� du kan medbringe hovedtelefonerne overalt.

Google Assistant: Brug blot din stemme til at afspille og styre din musik, modtage beskeder, h�ndtere dine daglige opgaver og f� svar takket v�re Google Assistant, der er direkte bygget ind i hovedtelefonerne. Brug en Action knap p� den h�jre hovedtelefon til at starte kommunikationen med din assistent. Har du ikke Google Assistant, s� kan du bruge denne knap til at justere niveauet af den aktive noise-cancelling.

Aktiv noise-cancelling: Hovedtelefonerne anvender indbyggede mikrofoner, der analyserer ekstern lyd og giver et modsvarende afvisende signal. Dette eliminerer lyden fra dine omgivelser og lader dig fokusere alene p� din krystalklare lyd-kilde � hvad enten du lytter til musik, lydbog, film eller anden underholdning.

Bluetooth: Hovedtelefonerne har tr�dl�s Bluetooth-forbindelse med A2DP-profil. Dette giver mulighed for tr�dl�s streaming uden besv�r med ledninger. NFC-teknologien lader dig parre hovedtelefonerne via et hurtigt tryk, eller du kan ogs� bruge et 3,5 mm standard lydkabel.

Lang batteritid: Hovedtelefonerne har indbygget Litium-ion-batteri, der giver op til 20 timers afspilning i tr�dl�s tilstand. Oplad batteriet med det medf�lgende USB-kabel. En fuld opladning tager 2,25 timer, mens en 15-minutters hurtig opladning giver op til 2,5 timers afspilning.

Flere egenskaber:
- Volume-balanceret EQ sikrer trov�rdig lydprofil ved forskellige lydniveauer i forskellige genrer
- Styringsknapper p� �rekapslen
- LED-indikatorer p� �rekapslen viser status for parring, opladning og batteriniveau
- Dual noise-cancelling mikrofoner giver telefonsamtaler med krystalklar lyd
- TriPort-�rekapseldesign
- Bose Connect-app til styring af indstillingerne

Inkluderet:
- Bose QuietComfort tr�dl�se hovedtelefoner II
- USB-opladerkabel
- Lydkabel
- Rejseetui',
1999,4,6,3),
('Apple AirPods Pro tr�dl�se h�retelefoner','Apple AirPods bliver bare bedre og bedre. De innovative Apple AirPods Pro tr�dl�se h�retelefoner forbedrer designet ved at tilf�je en Force sensor for simpel kontrol og indstillelige �restykker for ekstra komfort og stabil pasform. De har Active Noise Cancellation og fremragende lyd.

True Wireless
AirPods Pro tilbyder kvalitetslyd uden et eneste kabel mellem �restykkerne og enheden for at skabe en �gte f�lelse af frihed og fleksibilitet.

Aktiv st�jd�mpning
Lad dig ikke forstyrre af omverdenen takket v�re Active Noise Cancellation (ANC). AirPods Pro har en indbygget udadvendende mikrofon, der opfatter ekstern lyd, samt en indadvendende mikrofon, der lytter efter u�nsket lyd inde i dit �re for effektiv blokering af u�nsket lyd. ANC justeres 200 gange i sekundet for fuldt fordybende lyd. P� den m�de kan du engagere dig i musikken, podcasten eller telefonsamtalen.

Siri stemmekontrol
Brug stemmekommandoer til Siri for at styre afspilningen, justere lydstyrken, tjekke batteritiden p� dine AirPods Pro eller sp�rge din virtuelle assistent efter r�d og information - fra vejrudsigten til retningsangivelse og din kalender for dagen. De stemmedetekterende mikrofoner med beamforcing-teknologi sikrer krystalklar lydgenkendelse, og du beh�ver endda ikke tage din iPhone op af lommen.

Force sensor
Tag eller afslut telefonopkald, styr musikken eller skift mellem ANC og Transparency tilstanden med en-knaps fjernbetjeningen p� h�retelefonen. Hvis du bruger begge AirPods eller blot en enkelt som h�ndfri fungerer h�jttaleren og mikrofonen samtidigt.

Sved- og vandresistens
AirPods Pro f�lger med dig til selv den h�rdeste tr�ning, og du beh�ver ikke bekymre dig om at hovedtelefonerne bliver v�de.

Transparency tilstand
Tryk p� Force sensoren for at skifte fra ANC til transparency-tilstand p� f� sekunder og uden at forstyrre musikken. Transparency-tilstanden lukker lyd ind udefra, n�r der er brug for det.

Batteritid
N�r de er fuldt opladede yder AirPods Pro op til 4,5 timers batteritid, noget af en pr�station i forhold til deres beskedne st�rrelse. Det inkluderede tr�dl�se opladeretui tilbyder adskillige genopladninger, s� du kan bruge AirPods Pro i op til 24 timer. Blot 5 minutter i opladeretuiet giver 1 ekstra times lyttetid.

Forbindelse og kompatibilitet
AirPods Pro bruger Apples forbedrede H1 chip for lynhurtig parring med din iPhone. Du kan ogs� forbinde dem til andre lydenheder med tr�dl�s Bluetooth-overf�rsel - eksempelvis �ldre iPhones, Mac computere, iPad eller iPod touch. AirPods Pro er kompatible med iPhone, iPad eller iPod touch enheder, der k�rer iOS 12.2 eller senere, Apple Watch p� watchOS 5.2 eller senere, Mac enheder p� macOS 10.14.4 eller senere.

Tr�dl�st opladeretui
Det tr�dl�se opladeretui kan let oplades ved at placere det p� enhver Qi-kompatibel tr�dl�s oplader eller gennem Lightning connectoren i bunden.',
2199,4,7,1),
('JBL Tune500BT tr�dl�se on-ear hovedtelefoner', 'F�l hver tone, hver basgang med de lette JBL Tune500 on-ear hovedtelefoner, der har et viklefrit fladt kabel som er klar, n�r du er.

JBL Pure Bass-lyd
JBL har en lang tradition for at skabe pr�cis, imponerende lyd, og den tradition f�lger disse hovedtelefoner, der blandt andet leverer en dyb, kraftfuld bas.

Bluetooth
Slip for kabler og ny bev�gelsesfriheden. Tune500BT er kompatible med alle Bluetooth-kompatible enheder. Forbind let alle dine enheder med Bluetooth 4.1 og stream musik tr�dl�s uden tab af lydkvalitet.

Simpel kontrol
Fjernbetjeningen p� hovedtelefonerne har integreret mikrofon og giver dig mulighed for at styre Siri eller Google Now, eller tage imod opkald og s� forts�tte med musikken uden at tage hovedtelefonerne af.

Lang batterilevetid
Med Tune500BT kan du nyde 12 timers brug p� en enkelt opladning. Den fulde opladning tager 2 timer, men hurtigopladningsfunktionen giver dig 1 times musik efter blot 5 minutters opladning.

Inkluderet i pakken
- JBL Tune500BT
- Opladerkabel
- Garanti/advarsler
- QSG/sikkerhedark',
399,4,8,5),
('Samsung 32* Full HD Smart TV UE32N5305','Med Samsung 32" Full HD Smart TVet UE32N5305 kan du se film, streame dine yndlingsserier eller se videoer og billeder fra din smartphone p� sk�rmen i krystalklar Full HD-kvalitet. TVets kompakte st�rrelse g�r den ideel til sovev�relset eller g�stev�relset.

Full HD opl�sning: Full HD opl�sning (1920 x 1080) leverer underholdning med realistisk, skarp og detaljeret billedkvalitet.

HDR (High Dynamic Range):HDR-teknologien sikrer, at m�rke omr�der i billedet vil v�re endnu m�rkere, og at lyse omr�der bliver endnu lysere. Dette skaber en mere realistisk billedoplevelse med flere farver, nuancer og kontraster. Resultatet bliver en mere realistisk TV-oplevelse.

PurColor
G� ikke glip af en eneste detalje p� sk�rmen og nyd de naturlige farver, der ikke er overdrevne. PurColor-funktionen sikrer at du f�r en naturlig farvegengivelse.

Micro Dimming Pro
Samsungs d�mpningsteknologi giver din synsoplevelse et ideelt kontrast- og farveniveau, hvilket resulterer i et knivskarpt billede. Ved individuelt at analysere hver eneste lille zone p� sk�rmen, vises alle film eller TV-serier i de bedste farver, lysstyrke, skarphed og skyggedetaljer.

Ultra Clean View
Nyd h�jere billedkvalitet med mindre forvr�ngning takker v�re Ultra Clean View, som analyserer det originale indhold via en avanceret algoritme.

Sk�rmspejling (Clone View)
Del indholdet fra din smartenhed p� TV-sk�rmen (alt efter hvad din mobile enhed underst�tter. Den viser kun indholdet fra din smartenhed p� TV-sk�rmen hvis de begge er tilsluttet til det samme netv�rk og er forbundet med hinanden via Allshare (DLNA)).

ConnectShare
Forbind dine digitale enheder. Du skal bare tilslutte et USB-stik eller en harddisk i TVet for at se billeder eller afspille musik.

Indbygget Wi-Fi
Nyd al online underholdning tr�dl�st uden at skulle bruge en wi-fi adapter. Dette Smart TV fra Samsung har indbygget wi-fi, s� du nemt kan g� p� opdagelse p� internettet, surfe eller streame tr�dl�st mellem forskellige enheder.

Placering
Leder du efter det perfekte sted at placere dit TV? Vi har et bredt udvalg af v�gbeslag, standere og andre smarte l�sninger til placering af dit nye TV.
Kabler og tilbeh�r
Planl�gger du at forbinde dit nye TV til en streaming-enhed, en spillekonsol, en Blu-ray-afspiller, en DVD-afspiller, eller en anden enhed? Find streamingenheder, kabler, adaptere og meget andet tilbeh�r i vores brede udvalg. Brug den bedste kvalitet og f� den bedste oplevelse ud af dit TV.

VESA m�l: 100x100

Inkluderet i pakken:
- Samsung UE55M5505
- Smart Remote fjernbetjening med batterier
- Str�mkabel
- Slankt Samsung Gender Cable
- Brugervejledning',
4498,6,9,5),
('Asus ROG Strix G 3 15,6* b�rbar gaming computer','Uanset om du spiller solo eller k�mper mod andre ved konkurrencepr�gede e-sportsturneringer g�lder �n ting � h�jt fps-tal. Og den b�rbare Asus ROG Strix G gaming computer leverer netop det.

Kabinet
Takket v�re det avancerede design og sk�rmen med en ultraslank ramme har denne b�rbare computer en mere kompakt st�rrelse end traditionelle b�rbare gaming computere. Scissor-sk�rmh�ngslerne giver en slankere ramme og giver mere plads til afk�ling.

9. generations kraft
Den kraftfulde 9. generations quad Core i5-processor fra Intel leverer exceptionel ydelse, n�r duf.eks. streamer. Processoren kan skiftes til 4,1 GHz turbotilstand, s� du kan spille kr�vende AAA-spil. Processoren f�lges af 8 GB hurtige DDR4 RAM.

Next-gen grafik
Det avancerede Nvidia GeForce GTX 1660 Ti grafikkort giver h�j ydelse og billedfrekvens samt forbedret billedkvalitet med et lavere str�mforbrug. Nyd skarpe Full HD-billeder selv i kr�vende 3D- og VR-spil.

120 Hz Full HD-sk�rm
15,6� IPS LED-sk�rmen har krystalklar Full HD 1080p-opl�sning for maksimal nydelse af spil og HD-videoer. Sk�rmen kan k�re ved 120 Hz frekvens, det dobbelte af en konventionel b�rbar computer, s� du kan nyde smidig handling � ogs� i spil med h�jt tempo. Og med en kort responstid p� 3 ms kan du handle hurtigt og f� en overh�nd i forhold til fjenden. IPS-teknologien sikrer bredere betragtningsvinkler, klarere farver og dybere sorte toner.

Tastatur
Tastaturet er testet til at have en livscyklus p� 20 millioner tastninger og har N-key rollover-funktion, s� du kan udf�re komplekse tastkombinationer. Aura Sync RGB-belysningen kan indstilles over 4 zoner og kan synkroniseres med lysbaren p� computerens kabinet, ROG-logoet p� l�get og andet Aura Sync-kompatibelt tilbeh�r.

Afk�ling
Med 3D Flow-afk�lingssystemet arbejder 2 robuste 12V bl�sere med tyndere blade og en massiv k�leplade med 5 varmer�r sammen for at fjerne varm luft s� hurtigt som muligt.

Anti-st�v selvreng�ring
2 separate kanaler skyder st�v og skidt ud fra k�lemekanismen, s� det ikke ophober sig i bl�serne. P� den m�de sikres stabil ydelse over tid.

Lyd
De sidefyrende stereoh�jttalere med 2x 4 Watt kraftoutput bruger SmartAmp-teknologi til at levere kraftfuld lyd, der placerer dig midt i handlingen.

Keystone-port
Denne s�rlige port p� siden af computeren kan bruges med en Asus Keystone NFC-enhed (s�lges separat), s� du med det samme kan skifte til personlige profiler og �bne for en krypteret del af harddisken, hvor du kan gemme s�rligt private data.

SSD-Lagring
Det lynhurtige 512 GB SSD drev giver ekstra korte booting- og loadingtider, s� du ikke skal spilde tid p� at vente, mens et spil starter.

HDMI
HDMI-outputtet kan forbindes til et HD TV eller en projektor, s� du kan vise billeder og videoer i op til 4K UHD-opl�sning p� en stor sk�rm.

Forbindelser:
- 1x vendbar USB-C 3.1 port med DisplayPort til video-output i op til 4K-opl�sning
- 3x USB 3.0 porte
- Lynhurtig wi-fi-ac med op til 1,7 Gbps b�ndbredde og RangeBoost multi-antenne-modtagelse
- Gigabit Ethernet LAN port, Bluetooth 5.0
- 3,5 mm kombineret hovedtelefon/mikrofon port

Andre funktioner:
- Integreret webcam med 720p HD-opl�sning
- Touchpad med multi-touch-kapacitet
- Windows 10 Home 64-bit
- 4-cellet Li-ion batteri med op til 7,5 timers batteritid',
10999,8,10,3)


insert into Adresser(postnrID,adresse,etage) values
(5230,'G�rtlervej 11',default), -- butik
(5220,'Nyborgvej 200a',default), -- butik
(7100,'Beriderbakken 4',default), -- butik
(5230,'R�deg�rdsvej 164', default), -- medarbejder
(5240,'Egeparken 158','12. th'), --medarbejder
(5792,'M�llevej 8',default), --medarbejder
(5230,'Henrik Hertz Vej 38',default), -- medarbejder
(5260,'Majsmarken 18',default), -- medarbejder
(6971,'�rnh�jvej 1B',default),-- medarbejder
(8305, 'Selsinggaarde 7', default),-- medarbejder
(2100,'Nordre Frihavnsgade 28','5. tv'),-- medarbejder
(2100,'�sterbrogade 49','st. tv'),-- medarbejder
(2100,'Jagtvej 183','3. th'),-- medarbejder
(9000,'Fredericiagade 27','1. tv'),-- medarbejder
(9000,'Schleppegrellsgade 50A','st. 2'),-- medarbejder
(6400,'Vester Snogb�k 33',default),-- medarbejder
(6400,'Vestvejen 2C',default),-- medarbejder
(5700,'Strammelse Gade 51','st. tv'),-- medarbejder
(5700,'Sdr Vorn�svej 19', default),-- kunde
(9990,'Tranevej 168', default),-- kunde
(9981,'Skagensvej 392', default),-- kunde
(9870,'Alb�kvej 46', default),-- kunde
(6430,'�sterhaven 25', default)-- kunde

insert into Butikker(adresseID) values
(1),
(2),
(3)

insert into Lager_Status(status) values
('P� Lager'),
('Ikke P� Lager'),
('P� Lager og Genbestilles'),
('Ikke P� Lager, men Genbestilles')

insert into Butikker_har_Vare(produktID,butikID,statusID,antal) values
(1,1,1,5),
(2,1,1,3),
(3,1,1,3),
(4,1,4,default),
(5,1,2,default),
(6,1,3,1),
(7,1,3,2),
(8,1,1,4),
(9,1,1,3),
(10,1,4,0),
(1,2,1,5),
(2,2,1,3),
(3,2,1,3),
(4,2,4,default),
(5,2,2,default),
(6,2,3,1),
(7,2,3,2),
(8,2,1,4),
(9,2,1,3),
(10,2,4,0),
(1,3,1,5),
(2,3,1,3),
(3,3,1,3),
(4,3,4,default),
(5,3,2,default),
(6,3,3,1),
(7,3,3,2),
(8,3,1,4),
(9,3,1,3),
(10,3,4,0)

insert into Afdelinger(afdeling,parent_Afdeling) values 
('Salgsafdeling', default),
('Salgschef', 1),
('Salgsassistent', 1),
('S�lger',1),
('Lagerafdeling',default),
('Lagerchef',5),
('Lagerfolk', 5)
-- adding It-support later

insert into Medarbejder(fornavn,efternavn,email,telefon,kontonr,reg,adresseID,afdelingID,butikID) values 
('Thomas', 'Pedersen','thomp@longiganten.dk','+45 72 38 63 18','4817491741','1943',4,2,1),
('Anna', 'Brunsviger','annb@longiganten.dk','+45 22 31 54 31','9182746517','3716',5,3,1),
('Chris', 'Kasaven','chrik@longiganten.dk','+45 50 21 15 18','3716253846','2817',6,4,1),
('Llona', 'Rasmussen','llonr@longiganten.dk','+45 22 71 33 33','3516371651','2019',7,6,1),
('Peter', 'Petersen','petp@longiganten.dk','+45 91 48 14 12','7163816351','2615',8,7,1),

('Morten', '�stergaard', 'moroe@longiganten.dk','+45 37 61 48 61','2736451947','2613',9,2,2),
('Mette','Frederiksen', 'metf@longiganten.dk','+45 23 21 22 22','3615283746','2134',10,3,2),
('Mattias', 'Tesfaye','matt@longiganten.dk','+45 31 73 16 55', '2281746611','2322',11,4,2),
('Nicolai','Wammen','nicw@longiganten.dk','+45 72 77 61 31','6255144717','2432',12,6,2),
('Jeppe','Kofod', 'jepk@longiganten.dk', '+45 77 77 51 51', '7766193131','8787',13,7,2),

('Nick','H�kkerup','nich@longiganten.dk','+45 61 45 90 00', '2716448817','2652',14,2,3),
('Astrid','Krag','astk@longiganten.dk','+45 55 59 50 51', '6410904160','2020',15,3,3),
('Morten','B�dskov', 'morb@longiganten.dk','+45 15 83 61 44', '5500197615','4311',16,4,3),
('Dan','J�rgensen', 'danj@longiganten.dk', '+45 35 09 16 90', '8071645566','2154',17,6,3),
('Pernille','Rosenkrantz-Theil','perr@longiganten.dk','+45 51 11 73 61', '6617663154','6536',18,7,3)

insert into Kunder(fornavn,efternavn,email,telefon) values
('Trine','Bramsen','trinebramsen@hotmail.com',default),
('Ane','Halsboe-J�rgensen','anehals@gmail.com','+45 22 13 04 05'),
('Simon', 'Kollerup','simonkol@hotmail.com','+45 87 13 61 30'),
('Peter','Hummelgaard', 'peterhummel@daglig.dk','+45 30 31 85 13'),
('Lea', 'Wermelin', 'miljoeministeren@mfvm.dk', '+45 38 14 21 42')

insert into Adresse_Type(type) values
('Privat'),
('Arbejd')

insert into Kunder_har_Adresser(adresseID,kundeID,adresseType) values 
(19,1,1),
(20,2,1),
(21,3,1),
(22,4,2),
(23,5,2)

insert into Ordre_Status(status) values
('Afventer'),
('Behandler'),
('Afsendt'),
('Annulleret')

insert into Ordre_Leverings_Metode(metodeNavn,pris) values
('Pakke (privatadresse)', 129),
('Pakke (pakkeshop)', 69),
('Pakke (erhvervsadresse)', 129),
('Hent i butik', 0)

insert into Ordre(kundeID,leveringsMetodeID,leveringsAdresseID,statusID) values
(1,1,19,1),
(2,1,20,1),
(3,2,21,2),
(4,3,22,2),
(5,3,23,3)


insert into Ordrelinjer(ordreID,produktID,antal,pris) values
(1,9,2,4498),
(1,6,1,1999),
(1,5,1,5999),
(2,3,1,5999),
(3,1,1,2969),
(4,9,10,4498),
(4,10,30,10999),
(5,4,5,2899),
(5,9,20,4498),
(5,3,80,5999)
*/

/*
insert into Kunder(fornavn,efternavn,email,telefon) values
('Kaj','Kastanje','kastanjer@hotmail.com',default)*/
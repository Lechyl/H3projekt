use LongigantenDB;

/*
insert into PostNr(byNavn) values ("test");


	insert into Kategorier(navn, parent_KategoriID) values
('Hvidevarer',default),
('Vaskemaskine',1),
('Lyd & Hi-Fi',default),
('Hovedtelefoner',3),
('TV & Billede',default),
('Fladskærms TV',5),
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
('Apple Inc','Anders kæld',default,'+45 73 31 57 41'),
('Intel Corporation','Emerkel Tarkov','tarkov@intel.com','+45 41 65 43 12'),
('Elgiganten Erhverv',default,'erhverv@elgiganten.dk','+45 70 70 27 70'),
('Lenovo Group Ltd','Lisa Lu','ll@lenovo.com','+86 389 1750389'),
('Samsung Electronics','Lee Kwang soo','lks@samsungelectronics.com','+45 91 74 14 84')

insert into Produkter(produktNavn,beskrivelse,pris,kategoriID,producentID,leverandorID) values
('Intel Core i7-9700K processor','Funktioner
- 8 cores/8 threads, 3,6 GHz base, 4,9 GHz turbofrekvens (på en enkelt kerne)
- 12 MB L3 cache
- LGA1151 fatning - kræver Intel 300-series chipset
- 95 W termal-design kraft
- Forbedret 14 nm lithography-proces
- Dual-channel DDR4 RAM understøtter op til 2.666 MHz
- Klar til Intel Optane hukommelse
- DirectX 12 understøttelse
- Integreret Intel UHD Graphics 630
- Understøtter 4K UHD output ved op til 60 Hz
- Blæserkøler ikke inkluderet',
2969,10,1,2
),
('AMD Ryzen 7 3700X processor','Byg en kraftfuld arbejdsstation eller en ultimativ gaming-computer med AMD Ryzen 7 3700X octa core processoren. Processoren har høj frekvensrækkevidde og ulåst clock-forstærker, der giver dig den perfekte mulighed til yderligere overclocking med en brugertilpasset termisk løsning.

Precision Boost Overdrive:Takket være Precision Boost teknologien kan processoren overclockes med en mere effektiv fordeling af arbejdsopgaverne og opnå en højere overordnet maks. frekvens.

Features:
- 8 kerner/16 tråde
- 3,6 GHz basisfrekvens, 4,4 GHz turbofrekvens
- Ulåst clock-forstærker
- 36 MB L2 + L3 cache
- AM4 fatning
- 65 W termisk designydelse
- Zen+ arkitektur med 7 nm FinFET litografiproces
- DDR4 RAM op til 3200 MHz understøttelse
- Inklusiv Wraith Prism blæsekøler m/ RGB LED',
2642,10,2,3
),
('Lenovo Ideapad L340 15,6* gaming-computer','Den bærbare Lenovo Ideapad L340 gaming computer er en ideel crossover mellem en kraftfuld gaming computer og en bærbar arbejdsstation. Den kan sagtens køre high-end AAA-spil uden problemer og du vil stadigvæk være i stand til at fuldføre dit seneste projekt.

Dual-mode drift
Skift til "Fast" mode for en førsteklasses præstation eller til "Quiet" mode, som er optimeret til effektivt at køre dine arbejdsopgaver uden at afkølingsblæserne skal køre for alt stærkt.

9. gen. effektivitet
Den bærbare computer er drevet af den højt ydende Intel Core i5 quad core processor fra Coffee Lake familien og kan let køre selv krævende spil. Processoren kan skifte til op til 4,1 GHz turbotilstand. Den er ledsaget af 8 GB hurtige DDR4 RAM.

Grafik
Med Nvidia GeForce GTX 1050 grafikkortet er forskellen på stationær og bærbar computer næsten udvisket. Grafikkortet er udstyret med 3 GB dedikerede RAM, så du kan nyde en fordybende gaming- og e-sportsoplevelse i Full HD 1080pp opløsning og med høj billedfrekvens.

Full HD skærm
Computerens 15,6” IPS LED skærm har krystalklar og detaljeret Full HD 1080p opløsning. De smalle rammer maksimerer skærmens plads uden at skabe unødvendige forstyrrelser. IPS-teknologien giver dybere kontraster, lysere farver og bredere synsvinkler.

Blålysfiltrering
Lenovo Vantage øjenbeskyttelsessoftwaren reducerer blålys output fra skærmen og reducerer dine øjnes belastning ved lange arbejdstimer.

Privatlivs webcam
Uanset om det gælder gaming uden forstyrrelser eller arbejde med fortrolige materialer, så forhindrer den fysiske webcam skodde uvedkommende fra at benytte dit kamera.

Batteri og opladning
Med sin store batterikapacitet kan den bærbare computer tilbyde op til 9,5 timers brugstid. Og takket være den hurtige opladning kan den oplades til op til 80 % kapacitet på bare 60 minutter og fuldkapacitet på bare 120 minutter.

Lyd
Stereo højttalerne er forbedrede med Dolby Audio lydbehandling, der kan levere en tordnende akustik på tværs af dit værelse.

Dobbelt lagring
Det lynhurtige 256 GB SSD drev giver ekstra korte booting- og loadingtider, så du ikke skal spilde tid på at vente, mens et spil starter.

HDMI
HDMI outputtet kan forbindes til et HD TV eller en projektor, så du kan vise billeder og video i Full HD 1080p opløsning på en større skærm.

Forbindelser:
- 1x vendbar USB-C 3.0 port
- 2x USB 3.0 porte
- Gigabit LAN port
- Lynhurtig wi-fi-ac og Bluetooth 4.2
- 3,5 mm lyd mini-jack

Andre egenskaber
- Windows 10 Home 64-bit styresystem
- Webcam med 720p HD opløsning
- Touchpad med multi-touch
- Bagbelyst tastatur med numerisk tastatur',
5999,8,3,4),
('Bosch Series 6 vaskemaskine','Bosch Series 6 vaskemaskinen kan klare al vasketøj, uanset hvor beskidt det er. Få friskt tøj efter hver vask.

8 kg kapacitet: Den generøse kapacitet går hånd i hånd med stor fleksibilitet. Vask et par enkelte klæder, eller tag hele ugens vask på én gang. Vask efter ferier, forlænget weekender og andre begivenheder vil ikke længere være et problem.

Programmer: Vaskemaskinen har en række praktiske hverdagsprogrammer som for eksempel et specielt program til uld, sarte stoffer samt ekstra hurtigt 15 minutters program.

VarioPerfect: Få vasketøjet hurtigt klaret eller vælg den den mest energieffektive løsning. SpeedPerfect kan forkorte vaskecyklussen med op til 65%, mens ecoPerfect forbruger 50% mindre energi sammenlignet med standardprogrammer.

VarioDrum: Dit tøj er sikret den mest skånsomme behandling takket være tromlens unikke design.

EcoSilence Drive: Den børsteløse motor har 10-års garanti og sikrer en effektiv samt stillegående drift.

Placering: Ved at tilføje gummifødder kan du øge stabiliteten og samtidigt reducere lyden fra apparatet. Hvis du ønsker at placere din tørretumbler ovenpå vaskemaskinen, kan du gøre dette ved at anvende et stablingssæt. Dette kræver dog, at både vaskemaskinen og tørretumbleren har samme mål. Derfor bør du være godt orienteret om målene på både din vaskemaskine og tørretumbler, før du anvender denne løsning.

Vedligeholdelse: Husk at din vaskemaskine har brug for regelmæssig rengøring af tromlen. Varme og fugtige miljøer kan gro mug, hvilket kan resultere i lugte, som ikke ønskes på tøj. Vælg korrekt vaskemiddel og forstærk rengøringseffekten.

Energiklasse: Denne Bosch-vaskemaskine forbruger 30% mindre energi end kravet til den bedste energiklasse A+++. Derfor er den et fremragende valg for dig, som er miljøbevidst og ønsker en vaskemaskine, som er ekstremt miljøvenlig og økonomisk i drift.

Fandt du ikke lige den Bosch vaskemaskine, du ledte efter? Se hele vores udvalg af Bosch vaskemaskiner her.',
2899,2,4,3),
('Siemens IQ700 vaskemaskine','Siemens IQ700 vaskemaskinen har fleksibel kapacitet, SpeedPerfect-funktion samt 11 praktiske programmer, som giver tøjet skånsom behandling.

8 kg kapacitet: Den generøse kapacitet giver stor fleksibilitet. Vask enkelte stykker tøj hurtigt eller vask vasketøjet fra hele ugen på én gang. Større mængder vasketøj fra ferier, forlænget weekender og lignende begivenheder vil ikke længere være noget problem.

iQdrive: Den holdbare børsteløse motor har 10 års garanti samt stillegående og energieffektiv drift.

SpeedPerfect: SpeedPerfect-funktionen identificerer automatisk muligheder for at spare tid og energiforbrug på hver vaskecyklusen. Derfor kan du du forkorte vaskecyklussen med op til 65% i tid.

LED-display: Oplev enkel betjening takket være det brugervenlig LED-display, der viser resterende tid og programinformation.

WaveDrum: Bliv kvit med bekymringer for, om tøjet sidder fast i tromlen. Den unikke kombination af dybe og lave kanter sikrer, at tøjet vaskes på en effektiv, men skånsom måde.

AntiVibration-panel: Panelet sikrer høj stabilitet, som bidrager til den stillegående drift på kun 48 dB.

WaterPerfect Plus: Det avanceret sensorsystem hjælper til at spare vandforbrug i hver vask. Sensoren justerer automatisk vandmængden efter hver tøjmængde. Funktionen hjælper derfor til at spare på udgifter uden at gå på kompromis med vaskeresultaterne.

Placering: Ved at tilføje gummifødder kan du øge stabiliteten og samtidigt reducere lyden fra apparatet. Hvis du ønsker at placere vaskemaskinen ovenpå din tørretumbler, kan du gøre dette ved at anvende et stablingssæt. Dette kræver dog, at både vaskemaskinen og tørretumbleren har samme mål. Derfor bør du være godt orienteret om målene på både din vaskemaskine og tørretumbler, før du anvender denne pladsbesparende løsning.

Vedligeholdelse: Husk at din vaskemaskine har brug for regelmæssig rengøring af tromlen. Varme og fugtige miljøer kan gro mug, hvilket kan resultere i lugte, som ikke ønskes på tøj. Indersiden af tromlen kan desinficeres ved at køre et program ved høj temperatur (gerne 85°C-90°C) med en tom vaskemaskine. Vælg det rigtige vaskemiddel og få den mest optimale rengøringseffekt.

Energiklasse: Denne vaskemaskine fra Siemens forbruger 30% mindre energi end kravet for energiklasse A+++. Perfekt til dig, det ønsker en ekstremt energieffektiv og økonomisk løsning.',
5999,2,5,3),
('Bose QuietComfort 35 QC35 II trådløse hovedtelefoner','De trådløse Bose QuietComfort hovedtelefoner II kommer med indbygget Google Assistant, der giver dig fuld kontrol over din musik, dine opkald og daglige opgaver via din stemme. Samtidig leverer de en førsteklasses lydoplevelse takket være blandt andet noise-cancelling-teknologien, der udelukker lyden fra dine omgivelser. Den trådløse Bluetooth-forbindelse med hurtig NFC-parring lader dig bruge hovedtelefonerne uden besvær med ledninger, og den trådløse forbindelse går ikke på kompromis med lydkvaliteten. Takket være den ekstra lange batteritid på op til 20 timer kan du bruge hovedtelefonerne i flere dage uden opladning. Og designet giver langvarig komfort takket være sine førsteklasses materialer og robuste konstruktion, der kan foldes, så du kan medbringe hovedtelefonerne overalt.

Google Assistant: Brug blot din stemme til at afspille og styre din musik, modtage beskeder, håndtere dine daglige opgaver og få svar takket være Google Assistant, der er direkte bygget ind i hovedtelefonerne. Brug en Action knap på den højre hovedtelefon til at starte kommunikationen med din assistent. Har du ikke Google Assistant, så kan du bruge denne knap til at justere niveauet af den aktive noise-cancelling.

Aktiv noise-cancelling: Hovedtelefonerne anvender indbyggede mikrofoner, der analyserer ekstern lyd og giver et modsvarende afvisende signal. Dette eliminerer lyden fra dine omgivelser og lader dig fokusere alene på din krystalklare lyd-kilde – hvad enten du lytter til musik, lydbog, film eller anden underholdning.

Bluetooth: Hovedtelefonerne har trådløs Bluetooth-forbindelse med A2DP-profil. Dette giver mulighed for trådløs streaming uden besvær med ledninger. NFC-teknologien lader dig parre hovedtelefonerne via et hurtigt tryk, eller du kan også bruge et 3,5 mm standard lydkabel.

Lang batteritid: Hovedtelefonerne har indbygget Litium-ion-batteri, der giver op til 20 timers afspilning i trådløs tilstand. Oplad batteriet med det medfølgende USB-kabel. En fuld opladning tager 2,25 timer, mens en 15-minutters hurtig opladning giver op til 2,5 timers afspilning.

Flere egenskaber:
- Volume-balanceret EQ sikrer troværdig lydprofil ved forskellige lydniveauer i forskellige genrer
- Styringsknapper på ørekapslen
- LED-indikatorer på ørekapslen viser status for parring, opladning og batteriniveau
- Dual noise-cancelling mikrofoner giver telefonsamtaler med krystalklar lyd
- TriPort-ørekapseldesign
- Bose Connect-app til styring af indstillingerne

Inkluderet:
- Bose QuietComfort trådløse hovedtelefoner II
- USB-opladerkabel
- Lydkabel
- Rejseetui',
1999,4,6,3),
('Apple AirPods Pro trådløse høretelefoner','Apple AirPods bliver bare bedre og bedre. De innovative Apple AirPods Pro trådløse høretelefoner forbedrer designet ved at tilføje en Force sensor for simpel kontrol og indstillelige ørestykker for ekstra komfort og stabil pasform. De har Active Noise Cancellation og fremragende lyd.

True Wireless
AirPods Pro tilbyder kvalitetslyd uden et eneste kabel mellem ørestykkerne og enheden for at skabe en ægte følelse af frihed og fleksibilitet.

Aktiv støjdæmpning
Lad dig ikke forstyrre af omverdenen takket være Active Noise Cancellation (ANC). AirPods Pro har en indbygget udadvendende mikrofon, der opfatter ekstern lyd, samt en indadvendende mikrofon, der lytter efter uønsket lyd inde i dit øre for effektiv blokering af uønsket lyd. ANC justeres 200 gange i sekundet for fuldt fordybende lyd. På den måde kan du engagere dig i musikken, podcasten eller telefonsamtalen.

Siri stemmekontrol
Brug stemmekommandoer til Siri for at styre afspilningen, justere lydstyrken, tjekke batteritiden på dine AirPods Pro eller spørge din virtuelle assistent efter råd og information - fra vejrudsigten til retningsangivelse og din kalender for dagen. De stemmedetekterende mikrofoner med beamforcing-teknologi sikrer krystalklar lydgenkendelse, og du behøver endda ikke tage din iPhone op af lommen.

Force sensor
Tag eller afslut telefonopkald, styr musikken eller skift mellem ANC og Transparency tilstanden med en-knaps fjernbetjeningen på høretelefonen. Hvis du bruger begge AirPods eller blot en enkelt som håndfri fungerer højttaleren og mikrofonen samtidigt.

Sved- og vandresistens
AirPods Pro følger med dig til selv den hårdeste træning, og du behøver ikke bekymre dig om at hovedtelefonerne bliver våde.

Transparency tilstand
Tryk på Force sensoren for at skifte fra ANC til transparency-tilstand på få sekunder og uden at forstyrre musikken. Transparency-tilstanden lukker lyd ind udefra, når der er brug for det.

Batteritid
Når de er fuldt opladede yder AirPods Pro op til 4,5 timers batteritid, noget af en præstation i forhold til deres beskedne størrelse. Det inkluderede trådløse opladeretui tilbyder adskillige genopladninger, så du kan bruge AirPods Pro i op til 24 timer. Blot 5 minutter i opladeretuiet giver 1 ekstra times lyttetid.

Forbindelse og kompatibilitet
AirPods Pro bruger Apples forbedrede H1 chip for lynhurtig parring med din iPhone. Du kan også forbinde dem til andre lydenheder med trådløs Bluetooth-overførsel - eksempelvis ældre iPhones, Mac computere, iPad eller iPod touch. AirPods Pro er kompatible med iPhone, iPad eller iPod touch enheder, der kører iOS 12.2 eller senere, Apple Watch på watchOS 5.2 eller senere, Mac enheder på macOS 10.14.4 eller senere.

Trådløst opladeretui
Det trådløse opladeretui kan let oplades ved at placere det på enhver Qi-kompatibel trådløs oplader eller gennem Lightning connectoren i bunden.',
2199,4,7,1),
('JBL Tune500BT trådløse on-ear hovedtelefoner', 'Føl hver tone, hver basgang med de lette JBL Tune500 on-ear hovedtelefoner, der har et viklefrit fladt kabel som er klar, når du er.

JBL Pure Bass-lyd
JBL har en lang tradition for at skabe præcis, imponerende lyd, og den tradition følger disse hovedtelefoner, der blandt andet leverer en dyb, kraftfuld bas.

Bluetooth
Slip for kabler og ny bevægelsesfriheden. Tune500BT er kompatible med alle Bluetooth-kompatible enheder. Forbind let alle dine enheder med Bluetooth 4.1 og stream musik trådløs uden tab af lydkvalitet.

Simpel kontrol
Fjernbetjeningen på hovedtelefonerne har integreret mikrofon og giver dig mulighed for at styre Siri eller Google Now, eller tage imod opkald og så fortsætte med musikken uden at tage hovedtelefonerne af.

Lang batterilevetid
Med Tune500BT kan du nyde 12 timers brug på en enkelt opladning. Den fulde opladning tager 2 timer, men hurtigopladningsfunktionen giver dig 1 times musik efter blot 5 minutters opladning.

Inkluderet i pakken
- JBL Tune500BT
- Opladerkabel
- Garanti/advarsler
- QSG/sikkerhedark',
399,4,8,5),
('Samsung 32* Full HD Smart TV UE32N5305','Med Samsung 32" Full HD Smart TVet UE32N5305 kan du se film, streame dine yndlingsserier eller se videoer og billeder fra din smartphone på skærmen i krystalklar Full HD-kvalitet. TVets kompakte størrelse gør den ideel til soveværelset eller gæsteværelset.

Full HD opløsning: Full HD opløsning (1920 x 1080) leverer underholdning med realistisk, skarp og detaljeret billedkvalitet.

HDR (High Dynamic Range):HDR-teknologien sikrer, at mørke områder i billedet vil være endnu mørkere, og at lyse områder bliver endnu lysere. Dette skaber en mere realistisk billedoplevelse med flere farver, nuancer og kontraster. Resultatet bliver en mere realistisk TV-oplevelse.

PurColor
Gå ikke glip af en eneste detalje på skærmen og nyd de naturlige farver, der ikke er overdrevne. PurColor-funktionen sikrer at du får en naturlig farvegengivelse.

Micro Dimming Pro
Samsungs dæmpningsteknologi giver din synsoplevelse et ideelt kontrast- og farveniveau, hvilket resulterer i et knivskarpt billede. Ved individuelt at analysere hver eneste lille zone på skærmen, vises alle film eller TV-serier i de bedste farver, lysstyrke, skarphed og skyggedetaljer.

Ultra Clean View
Nyd højere billedkvalitet med mindre forvrængning takker være Ultra Clean View, som analyserer det originale indhold via en avanceret algoritme.

Skærmspejling (Clone View)
Del indholdet fra din smartenhed på TV-skærmen (alt efter hvad din mobile enhed understøtter. Den viser kun indholdet fra din smartenhed på TV-skærmen hvis de begge er tilsluttet til det samme netværk og er forbundet med hinanden via Allshare (DLNA)).

ConnectShare
Forbind dine digitale enheder. Du skal bare tilslutte et USB-stik eller en harddisk i TVet for at se billeder eller afspille musik.

Indbygget Wi-Fi
Nyd al online underholdning trådløst uden at skulle bruge en wi-fi adapter. Dette Smart TV fra Samsung har indbygget wi-fi, så du nemt kan gå på opdagelse på internettet, surfe eller streame trådløst mellem forskellige enheder.

Placering
Leder du efter det perfekte sted at placere dit TV? Vi har et bredt udvalg af vægbeslag, standere og andre smarte løsninger til placering af dit nye TV.
Kabler og tilbehør
Planlægger du at forbinde dit nye TV til en streaming-enhed, en spillekonsol, en Blu-ray-afspiller, en DVD-afspiller, eller en anden enhed? Find streamingenheder, kabler, adaptere og meget andet tilbehør i vores brede udvalg. Brug den bedste kvalitet og få den bedste oplevelse ud af dit TV.

VESA mål: 100x100

Inkluderet i pakken:
- Samsung UE55M5505
- Smart Remote fjernbetjening med batterier
- Strømkabel
- Slankt Samsung Gender Cable
- Brugervejledning',
4498,6,9,5),
('Asus ROG Strix G 3 15,6* bærbar gaming computer','Uanset om du spiller solo eller kæmper mod andre ved konkurrenceprægede e-sportsturneringer gælder én ting – højt fps-tal. Og den bærbare Asus ROG Strix G gaming computer leverer netop det.

Kabinet
Takket være det avancerede design og skærmen med en ultraslank ramme har denne bærbare computer en mere kompakt størrelse end traditionelle bærbare gaming computere. Scissor-skærmhængslerne giver en slankere ramme og giver mere plads til afkøling.

9. generations kraft
Den kraftfulde 9. generations quad Core i5-processor fra Intel leverer exceptionel ydelse, når duf.eks. streamer. Processoren kan skiftes til 4,1 GHz turbotilstand, så du kan spille krævende AAA-spil. Processoren følges af 8 GB hurtige DDR4 RAM.

Next-gen grafik
Det avancerede Nvidia GeForce GTX 1660 Ti grafikkort giver høj ydelse og billedfrekvens samt forbedret billedkvalitet med et lavere strømforbrug. Nyd skarpe Full HD-billeder selv i krævende 3D- og VR-spil.

120 Hz Full HD-skærm
15,6” IPS LED-skærmen har krystalklar Full HD 1080p-opløsning for maksimal nydelse af spil og HD-videoer. Skærmen kan køre ved 120 Hz frekvens, det dobbelte af en konventionel bærbar computer, så du kan nyde smidig handling – også i spil med højt tempo. Og med en kort responstid på 3 ms kan du handle hurtigt og få en overhånd i forhold til fjenden. IPS-teknologien sikrer bredere betragtningsvinkler, klarere farver og dybere sorte toner.

Tastatur
Tastaturet er testet til at have en livscyklus på 20 millioner tastninger og har N-key rollover-funktion, så du kan udføre komplekse tastkombinationer. Aura Sync RGB-belysningen kan indstilles over 4 zoner og kan synkroniseres med lysbaren på computerens kabinet, ROG-logoet på låget og andet Aura Sync-kompatibelt tilbehør.

Afkøling
Med 3D Flow-afkølingssystemet arbejder 2 robuste 12V blæsere med tyndere blade og en massiv køleplade med 5 varmerør sammen for at fjerne varm luft så hurtigt som muligt.

Anti-støv selvrengøring
2 separate kanaler skyder støv og skidt ud fra kølemekanismen, så det ikke ophober sig i blæserne. På den måde sikres stabil ydelse over tid.

Lyd
De sidefyrende stereohøjttalere med 2x 4 Watt kraftoutput bruger SmartAmp-teknologi til at levere kraftfuld lyd, der placerer dig midt i handlingen.

Keystone-port
Denne særlige port på siden af computeren kan bruges med en Asus Keystone NFC-enhed (sælges separat), så du med det samme kan skifte til personlige profiler og åbne for en krypteret del af harddisken, hvor du kan gemme særligt private data.

SSD-Lagring
Det lynhurtige 512 GB SSD drev giver ekstra korte booting- og loadingtider, så du ikke skal spilde tid på at vente, mens et spil starter.

HDMI
HDMI-outputtet kan forbindes til et HD TV eller en projektor, så du kan vise billeder og videoer i op til 4K UHD-opløsning på en stor skærm.

Forbindelser:
- 1x vendbar USB-C 3.1 port med DisplayPort til video-output i op til 4K-opløsning
- 3x USB 3.0 porte
- Lynhurtig wi-fi-ac med op til 1,7 Gbps båndbredde og RangeBoost multi-antenne-modtagelse
- Gigabit Ethernet LAN port, Bluetooth 5.0
- 3,5 mm kombineret hovedtelefon/mikrofon port

Andre funktioner:
- Integreret webcam med 720p HD-opløsning
- Touchpad med multi-touch-kapacitet
- Windows 10 Home 64-bit
- 4-cellet Li-ion batteri med op til 7,5 timers batteritid',
10999,8,10,3)


insert into Adresser(postnrID,adresse,etage) values
(5230,'Gørtlervej 11',default), -- butik
(5220,'Nyborgvej 200a',default), -- butik
(7100,'Beriderbakken 4',default), -- butik
(5230,'Rødegårdsvej 164', default), -- medarbejder
(5240,'Egeparken 158','12. th'), --medarbejder
(5792,'Møllevej 8',default), --medarbejder
(5230,'Henrik Hertz Vej 38',default), -- medarbejder
(5260,'Majsmarken 18',default), -- medarbejder
(6971,'Ørnhøjvej 1B',default),-- medarbejder
(8305, 'Selsinggaarde 7', default),-- medarbejder
(2100,'Nordre Frihavnsgade 28','5. tv'),-- medarbejder
(2100,'Østerbrogade 49','st. tv'),-- medarbejder
(2100,'Jagtvej 183','3. th'),-- medarbejder
(9000,'Fredericiagade 27','1. tv'),-- medarbejder
(9000,'Schleppegrellsgade 50A','st. 2'),-- medarbejder
(6400,'Vester Snogbæk 33',default),-- medarbejder
(6400,'Vestvejen 2C',default),-- medarbejder
(5700,'Strammelse Gade 51','st. tv'),-- medarbejder
(5700,'Sdr Vornæsvej 19', default),-- kunde
(9990,'Tranevej 168', default),-- kunde
(9981,'Skagensvej 392', default),-- kunde
(9870,'Albækvej 46', default),-- kunde
(6430,'Østerhaven 25', default)-- kunde

insert into Butikker(adresseID) values
(1),
(2),
(3)

insert into Lager_Status(status) values
('På Lager'),
('Ikke På Lager'),
('På Lager og Genbestilles'),
('Ikke På Lager, men Genbestilles')

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
('Sælger',1),
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

('Morten', 'Østergaard', 'moroe@longiganten.dk','+45 37 61 48 61','2736451947','2613',9,2,2),
('Mette','Frederiksen', 'metf@longiganten.dk','+45 23 21 22 22','3615283746','2134',10,3,2),
('Mattias', 'Tesfaye','matt@longiganten.dk','+45 31 73 16 55', '2281746611','2322',11,4,2),
('Nicolai','Wammen','nicw@longiganten.dk','+45 72 77 61 31','6255144717','2432',12,6,2),
('Jeppe','Kofod', 'jepk@longiganten.dk', '+45 77 77 51 51', '7766193131','8787',13,7,2),

('Nick','Hækkerup','nich@longiganten.dk','+45 61 45 90 00', '2716448817','2652',14,2,3),
('Astrid','Krag','astk@longiganten.dk','+45 55 59 50 51', '6410904160','2020',15,3,3),
('Morten','Bødskov', 'morb@longiganten.dk','+45 15 83 61 44', '5500197615','4311',16,4,3),
('Dan','Jørgensen', 'danj@longiganten.dk', '+45 35 09 16 90', '8071645566','2154',17,6,3),
('Pernille','Rosenkrantz-Theil','perr@longiganten.dk','+45 51 11 73 61', '6617663154','6536',18,7,3)

insert into Kunder(fornavn,efternavn,email,telefon) values
('Trine','Bramsen','trinebramsen@hotmail.com',default),
('Ane','Halsboe-Jørgensen','anehals@gmail.com','+45 22 13 04 05'),
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
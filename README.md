# Lernperiode-8
Hier lernen wir neue Technologien kennen. (schauen Sie zuerst auf Branch: Master, da ich ein Fehler gemacht habe beides beim Pushen und beim Programmkonzept)

Für die nächsten 4 Wochen gibt es 3 Technologien/Frameworks, die mich am meisten interessieren:
- Godot
- TypeScript in Angular
- Spectre.Console

Ich habe mich dafür entschieden, zuerst **Spectre.Console** zu lernen, da ich es sehr gut für strukturierte, visuelle Konsolenprogramme einsetzen kann.

---

# Nuclear Reactor Command Center  
### C# Konsolen-App mit Spectre.Console

## Ziel

Dieses Projekt dient dazu, **Spectre.Console** intensiv kennenzulernen und anzuwenden.  
Der Fokus liegt **nicht** auf realistischen physikalischen Berechnungen oder komplexer C#-Logik, sondern auf der **visuellen Darstellung von Informationen in der Konsole**.

Das Programm simuliert ein **nukleares Reaktor-Kontrollzentrum**, in dem verschiedene Systeme überwacht und gesteuert werden. Alle Daten sind fiktiv und dienen ausschließlich der Darstellung.

**Zentrales Lernziel:**
- Effektiver Einsatz von **Spectre.Console** zur Darstellung komplexer Informationen:
  - Tables
  - Panels
  - Layouts
  - Farben & Markup
  - Progress Bars
  - Live-Updates
  - Benutzerinteraktion (Prompts)
  - Canvas (damit wirklich alle Features abgedekct sind)

---

## Projektidee

Das Programm stellt ein textbasiertes Kontrollzentrum dar, ähnlich einem technischen Dashboard.

Beispiele für dargestellte Systeme:
- Reaktorkern(e)
- Kühlsysteme
- Stromerzeuger
- Trafos
- Nuklearmaterialverwaltung
- Alarmsystem

Der Benutzer kann Zustände einsehen, simulierte Aktionen auslösen und visuelle Rückmeldungen erhalten.

---

## Geplante Features (Spectre.Console-Fokus)

- **Dashboard-Layout**
  - Mehrspaltiges Layout mit Statusübersicht, Detailansicht und Log-Bereich
- **Systemübersicht**
  - Tabellen mit Systemnamen, Zustand und Farbcodierung
- **Statusanzeigen**
  - Panels für kritische Informationen und Warnungen
- **Simulation von Abläufen**
  - Fortschrittsbalken für Wartung, Notfallmaßnahmen oder Systemchecks
- **Farben & Markup**
  - Grün = stabil
  - Gelb = Warnung
  - Rot = kritisch
- **Benutzerinteraktion**
  - Menüs und Auswahldialoge zur Steuerung von Aktionen
- **Live-Aktualisierung**
  - Sich verändernde Werte und Statusanzeigen in Echtzeit, auch mit Graphen

---

## Arbeitspakete

### Heute starten (max. 1,5 Stunden)

- [x] **Projekt-Setup**
   - Neues C#-Konsolenprojekt
   - Spectre.Console einrichten

- [x] **Grundlayout**
   - Einfaches Testdashboard mit Layout oder Panels erstellen

- [ ] **Erste Systemanzeige**
   - Tabelle mit 2–3 Reaktorsystemen und farbigen Statuswerten

- [x] **Testlauf**
   - Sicherstellen, dass Layout, Farben und Darstellung stabil funktionieren


Heute habe ich sehr viel am Backend gearbeitet. Ich habe jetzt 17 Classes wenn mann die MSTestsettings nicht zählt. Ich habe meine Classes mit MSTest tests getestet damit ich nacher kein Ärger damit habe. Da der Punkt für diese Lernperiode nicht ist, backends zu machen sonder eher um Spectre zu lernen, habe ich mit verschiedene Funktionen herumgespielt, um ein Reaktor "Strahlungsdiagramm" (gar nicht realistisches) zu erstellen.
---

### Nächste Woche – Arbeitspakete


- [ ] **Systemmodell**
   - Einfache `SystemStatus`-Struktur (Name, Zustand, Beschreibung)

- [ ] **Erweiterte Visualisierung**
   - Mehrere Panels und Tabellen in einem festen Layout kombinieren

- [ ] **Fortschrittsanzeigen**
   - Simulierte Prozesse mit Progress Bars (z. B. Kühlung stabilisieren)

- [ ] **Interaktion**
   - Auswahlmenüs für Aktionen (System prüfen, Wartung starten, Alarm quittieren)

---

## Abgrenzung

- Keine reale Reaktorlogik
- Keine physikalisch korrekten Berechnungen
- Keine sicherheitsrelevanten Inhalte

Der Fokus liegt ausschließlich auf:
> **Darstellung, Struktur und Benutzerführung in der Konsole mit Spectre.Console**

---

## Warum dieses Projekt?

Dieses Projekt eignet sich besonders gut, um:
- viele Features von Spectre.Console sinnvoll einzusetzen
- komplexe Informationen übersichtlich darzustellen
- ein visuell beeindruckendes Konsolenprogramm zu entwickeln
- ein klar abgegrenztes, schulisch relevantes Lernziel zu verfolgen

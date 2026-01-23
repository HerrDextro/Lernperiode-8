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

- [x] **Erste Systemanzeige**
   - Tabelle mit 2–3 Reaktorsystemen und farbigen Statuswerten

- [x] **Testlauf**
   - Sicherstellen, dass Layout, Farben und Darstellung stabil funktionieren
---
<small>Heute habe ich viel am "Backend" gearbeitet. Ich habe jetzt 17 Klassen, wenn man die MSTest-Settings nicht mitzählt. Ich habe die Klassen mit MSTest getestet, um später keine Probleme zu bekommen. Da der Punkt dieser Lernperiode nicht das Backend ist, sondern Spectre.Console, habe ich verschiedene Funktionen ausprobiert, um ein (nicht realistisches) Reaktor-Strahlungsdiagramm zu erstellen.</small>

### 23.01.2026 – Arbeitspakete


- [x] **Fertigmachen der Basisfunktionalität vom Code**
   - Projekt läuft ohne errors, instanziiert Objekte richtig.

- [x] **Erweiterte Visualisierung**
   - Ausprobierte Spectre Elemente für Reaktor gestaltet

- [x] **Fortschrittsanzeigen**
   - Simulierte Prozesse mit Progress Bars (Geschichte von MW Nutzung)

- [x] **Console Layout gestalten**
   - Alle ausprobierte Elemente von Spectre in ihrem PLatz auf dem Consolenfenster organisiert (6 Hauptblöcke, 3 Columns, 2 rows) und unten Navigation
     
<small>Heute habe ich die Basisfunktionen fertiggestellt, alles, was zum Laufen nötig ist, außer UI-spezifische Aktionen (z. B. FuelRods wechseln). Außerdem habe ich alle benötigten Spectre-Features in einer Testklasse ausprobiert. Jetzt kenne ich alle Features und habe ein Layout für die Console erstellt. Dieses läuft in einem GameLoop ähnlich einem Videospiel und rendert die Console jedes Frame. Es funktioniert, allerdings gibt es ein starkes Flickern, da das Layout schnell gelöscht und neu gezeichnet wird. Die dargestellten Daten sind derzeit noch Platzhalter. Als Nächstes möchte ich alle Systeme darstellen, Dialoge hinzufügen und mehrere „Tabs“ der Console ermöglichen, sowie echte Simulationsdaten verwenden.</small>
---

### Nächstes Mal – Arbeitspakete


- [ ] **Console-Finalisierung**
   - Einfache `SystemStatus`-Struktur (Name, Zustand, Beschreibung)

- [ ] **Echte Daten**
   - Mehrere Panels und Tabellen in einem festen Layout kombinieren

- [ ] **Spectre Tutorial**
   - Simulierte Prozesse mit Progress Bars (z. B. Kühlung stabilisieren)

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

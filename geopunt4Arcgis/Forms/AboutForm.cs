﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace geopunt4Arcgis
{
    public partial class AboutGeopunt4arcgisForm : Form
    {
        geopunt4arcgisExtension gpExtension;

        public AboutGeopunt4arcgisForm()
        {
            gpExtension = geopunt4arcgisExtension.getGeopuntExtension();

            InitializeComponent();
            this.Text = String.Format("About {0}", ThisAddIn.Name);
            this.labelProductName.Text = String.Format("Naam: {0}", ThisAddIn.Name); 
            this.labelVersion.Text = String.Format("Versie: {0} van {1}", ThisAddIn.Version, ThisAddIn.Date);
            this.labelAuthor.Text = String.Format("Auteur: {0}", ThisAddIn.Author);
            this.labelCompanyName.Text = String.Format("In opdracht van: {0}", ThisAddIn.Company);
            //string rootFolder = Path.GetDirectoryName(this.GetType().Assembly.Location);
            //htmlLocation = Path.Combine( rootFolder, "Resources/about.html");

            descriptionWebBox.DocumentText = getHtml();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.geopunt.be/nl/voor-experts/geopunt-plug-ins");
        }

        protected override void OnClosed(EventArgs e)
        {
            gpExtension.aboutDlg = null;
            base.OnClosed(e);
        }

        public string getHtml() 
        {
            string html = @"<!DOCTYPE html>
        <html>
        <head>
          <title>Over Geopunt4ArcGIS</title>
          <style>body {font-size: 80%}</style>
        </head>
        <body>
          <h1>Geopunt voor ArcGIS</h1>
          <h2>Functies</h2>
          <ul>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/zoek-een-adres' > Zoek een Adres</a>
            </li>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/prik-een-adres-op-kaart' > Prik een Adres op kaart</a>
            </li>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/csv-bestanden-geocoderen' > CSV-adresbestanden geocoderen</a>
            </li>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/poi' > Zoek een Plaats - interesse punt</a>
            </li>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/gipod' > GIPOD</a>
            </li>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/hoogteprofiel' > Hoogteprofiel</a>
            </li>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/zoek-een-perceel' > Zoek een perceel</a>
            </li>
            <li>
              <a href='http://www.geopunt.be/voor-experts/geopunt-plug-ins/arcgis%20plugin/functionaliteiten/catalogus' > Geopunt catalogus</a>
            </li>
          </ul>
          <h2>Systeem vereisten</h2>
          <ul>
            <li>Minimaal: Windows XP, ArcGIS Desktop versie 10.0 sp4 of hoger, .net-framework versie 3.5</li>
            <li>Aanbevolen: Windows7, ArcGIS Desktop versie 10.2 of hoger, .net-framework versie 4.0</li>
            <li>Een verbinding met het internet, restrictieve firewalls kunnen mogelijk de connectie blokkeren.</li>
          </ul>
          <h2>Doelstelling</h2>
          <p>Geopunt4arcgis - 'Geopunt voor ArcGIS' is een add-in voor ESRI ArcGIS desktop, die de webservices van het Vlaamse geoportaal Geopunt ontsluit naar desktop ArcGIS-gebruikers.</p>
          <p>Het Vlaamse Geoportaal Geopunt biedt een aantal geografische diensten (web-services) aan die mogen gebruikt worden door derden zoals andere overheden en bedrijven.</p>
          <p>
            De kaartdiensten zijn gebaseerd op de OGC open standaard WMS of WMTS en kunnen gemakkelijk worden toegevoegd aan desktop GIS. GIS-gebruikers kunnen deze diensten ontdekken via het <a href='https://metadata.geopunt.be'>metadatacenter</a>.
            De achterliggende zoekservice voor deze diensten is niet direct bruikbaar in QGIS en wordt in deze plugin ingebouwd.
          </p>
          <p>Sommige diensten aangeboden door geopunt zijn niet gebaseerd op een open standaard omdat het gaat om diensten die geen  courant gebruikte open standaard hebben. Deze publieke webdiensten bieden een REST-interface aan, die eenvoudiger in gebruik is voor programmeurs dan OGC-diensten, maar omdat ze niet gestandaardiseerd zijn, kunnen ze niet zomaar binnen getrokken worden in desktop software.</p>
          <p>Het gaat onder andere over:</p>
          <ul>
            <li>
              <strong>Geocoderen</strong>, gebaseerd op de officiële <a href='https://www.agiv.be/producten/crab'>CRAB</a> adressen-databank.
            </li>
            <li>
              <strong>Interessante locaties zoeken</strong> (points of interest). Typisch locaties beschikbaar gesteld door Vlaamse instanties.
            </li>
            <li>
              <strong>Innames van openbaar domein</strong>, van het Generiek Informatieplatform Openbaar Domein. Het <a href='http://gipod.api.agiv.be/#!index.md'>GIPOD</a> is de officiële databank met manifestaties, wegenwerken en andere obstructies op het openbaar domein.
            </li>
            <li>
              <strong>Hoogteprofiel</strong>, een dienst waarmee de hoogte, in digitaal hoogte model Vlaanderen, langsheen een lijn kan worden opgevraagd en gepresenteerd. De brondata is <a href='https://www.agiv.be/producten/digitaal-hoogtemodel-vlaanderen'>DHM-Vlaanderen</a>.
            </li>
            <li>
              <strong>Percelen zoeken</strong>, op getrapte wijze op de basis van gemeente naar departement, sectie dan naar perceelnummer in KADMAP.
            </li>
            <li>
              <strong>Metadata zoekdienst</strong>, dienst om datasets te zoeken via het <a href='https://metadata.geopunt.be'>metadatacenter</a> van Geopunt. Deze bevat ondermeer metadatasets van AGIV, het samenwerkingsverband MercatorNet en DOV.
            </li>
          </ul>
          <p>
            Om GIS gebruikers binnen en buiten de Vlaamse Overheid dezelfde functionaliteit ter beschikking te stellen als aangeboden in Geopunt, wenst AGIV deze gebruikers te voorzien van software plug-ins die deze functionaliteit geïntegreerd aanbieden binnen de meest gangbare GIS desktop  omgevingen.
            Op basis van voorafgaand overleg met de GDI-Vlaanderen gemeenschap werd volgende GIS software geselecteerd: Quantum GIS (QGIS) v2.0 Dufour en ESRI ArcMap v10.
          </p>
          <h2>Wat is Geopunt ?</h2>
          <p>
            <a href='http://www.geopunt.be/'>Geopunt</a> is de centrale toegangspoort tot geografische overheidsinformatie, en het uithangbord van het samenwerkingsverband voor geografische informatie in Vlaanderen (GDI-Vlaanderen). Het portaal richt zich met een uitgebreid data-, diensten- en toepassingenaanbod naar een breed en divers publiek. Van burgers op zoek naar een geschikte bouwgrond tot de GIS-coördinator of het studiebureau die een milieu-studie wensen uit te voeren. Het geoportaal maakt laagdrempelig gebruik van geografische informatie door zowel overheidsinstanties, burgers, organisaties als bedrijven mogelijk. Maatschappelijk relevante geografische gegevens en diensten worden op een slimme en gebruiksvriendelijke wijze bijeengebracht.
          </p>
          <p>
            Alle componenten (metadata-cataloog, downloadapplicatie, e-commerce-applicatie, data en netwerkdiensten) worden rechtstreeks en geïntegreerd aangeboden. Het geoportaal vormt het Vlaams knooppunt in een Europese geografische data-infrastructuur en voldoet aan de vereisten van de <a href='http://inspire-geoportal.ec.europa.eu/'>European INSPIRE richtlijn</a>.
          </p>
          <p>Geopunt is de website van het samenwerkingsverband voor geografische informatie binnen de Vlaamse overheid, GDI-Vlaanderen (GDI = Geografische Data Infrastructuur). In de rol van geografische dienstenintegrator en als uitvoerend orgaan van het samenwerkingsverband GDI-Vlaanderen staat het Agentschap voor Geografische Informatie Vlaanderen (AGIV) in voor de realisatie en het onderhoud van Geopunt.</p>
          <h2>Over de auteur</h2>
          <p>
            <a href='http://kgis.be'>Kay Warrie</a>
          </p>
          <p>Ik ben geodata analist en programmeur, werkzaam als freelance GIS consultant en bij de Studiedienst van stad Antwerpen.</p>
          <p>Professioneel werk ik op desktop GIS, voornamelijk Arcgis en QGIS en op webmapping met ESRI Arcgis-server of opensource webGIS en Maptiling Systemen. Ik beheer ook mee de centrale geodatabases van het stad en INSPIRE-compliant metadata in kader van GDI, Voor de rest doe ik vooral allerlei GIS analyses op data van het Stad. De meeste analyses zijn gerelateerd aan adressering-geocoding, ruimtelijke relaties, nabijheidsanalyses (routing, service area's ed.) voor onder andere MER studies, ruimtelijke ordening of bouwvergunningen.</p>
          <p>
            <a href='mailto:kaywarrie@gmail.com'>Contact mij</a>
          </p>
          <p>
            <a href='http://warrieka.github.io/#!aboutMe.md'>Meer over mij</a>
          </p>
          <h4>Online Bronnen:</h4>
          <ul>
            <li>
              <em>
                <a href='http://www.geopunt.be/voor-experts/geopunt-plugins'>http://www.geopunt.be</a>
              </em>
            </li>
            <li>
              <em>
                <a href='https://www.agiv.be/'>https://www.agiv.be/</a>
              </em>
            </li>
          </ul>
        </body>
        </html>";

            return html;
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TekgemExercise.CitySearch;

namespace TekgemExercise
{
    /// <summary>
    /// Base Program class, used here as an example of my algorithm.
    /// </summary>
    public class Program
    {
        // List to store cities and create the CityFinder.
        static List<string> cities = new List<string>();
        static CityFinder cityFinder;

        static void Main(string[] args)
        {
            // Create CityFinder and store the example cities
            cityFinder = new CityFinder();
            cities = new List<string>(new string[] { "Abingdon", "Accrington", "Acton", "Adlington", "Alcester", "Aldeburgh", "Aldershot", "Aldridge", "Alford", "Alfreton", "Alnwick", "Alsager", "Alston", "Alton", "Altrincham", "Amble", "Amersham", "Amesbury", "Ampthill", "Andover", "Appleby-in-Westmorland", "Arundel", "Ashbourne", "Ashburton", "Ashby-de-la-Zouch", "Ashford", "Ashington", "Ashton-in-Makerfield", "Ashton-under-Lyne", "Askern", "Aspatria", "Atherstone", "Attleborough", "Axbridge", "Axminster", "Aylesbury", "Aylsha", "Bacup", "Bakewell", "Baldock", "Banbury", "Barking", "Barnard Castle", "Barnet", "Barnoldswick", "Barnsley", "Barnstaple", "Barnt Green", "Barrow-in-Furness", "Barton-upon-Humber", "Barton-le-Clay", "Basildon", "Basingstoke", "Bath", "Batley", "Battle", "Bawtry", "Beaconsfield", "Beaminster", "Bebington", "Beccles", "Bedale", "Bedford", "Bedlington", "Bedworth", "Beeston", "Belper", "Bentham", "Berkhamsted", "Berwick-upon-Tweed", "Beverley", "Bewdley", "Bexhill-on-Sea", "Bicester", "Biddulph", "Bideford", "Biggleswade", "Billericay", "Bilston", "Bingham", "Birmingham", "Bishop Auckland", "Bishop's Castle", "Bishop's Stortford", "Bishop's Waltham", "Blackburn", "Blackpool", "Blandford Forum", "Bletchley", "Blyth", "Bodmin", "Bognor Regis", "Bollington", "Bolsover", "Bolton", "Bordon", "Borehamwood", "Boston", "Bottesford", "Bourne", "Bournemouth", "Brackley", "Bracknell", "Bradford", "Bradford-on-Avon", "Bradley Stoke", "Bradninch", "Braintree", "Brentford", "Brentwood", "Bridgnorth", "Bridgwater", "Bridlington", "Bridport", "Brierley Hill", "Brigg", "Brighouse", "Brightlingsea", "Brighton", "Bristol", "Brixham", "Broadstairs", "Bromley", "Bromsgrove", "Bromyard", "Brownhills", "Buckfastleigh", "Buckingham", "Bude", "Budleigh Salterton", "Bungay", "Buntingford", "Burford", "Burgess Hill", "Burnham-on-Crouch", "Burnham-on-Sea", "Burnley", "Burntwood", "Burton Latimer", "Burton-upon-Trent", "Bury", "Bury St Edmunds", "Buxton", "Blackbur", "Caistor", "Calne", "Camberley", "Camborne", "Cambridge", "Camelford", "Cannock", "Canterbury", "Carlisle", "Carnforth", "Carterton", "Castle Cary", "Castleford", "Chadderton", "Chagford", "Chard", "Charlbury", "Chatham", "Chatteris", "Chelmsford", "Cheltenham", "Chesham", "Cheshunt", "Chester", "Chesterfield", "Chester-le-Street", "Chichester", "Chippenham", "Chipping Campden", "Chipping Norton", "Chipping Ongar", "Chipping Sodbury", "Chorley", "Christchurch", "Church Stretton", "Cinderford", "Cirencester", "Clacton-on-Sea", "Cleckheaton", "Cleethorpes", "Clevedon", "Cleveleys", "Clitheroe", "Clun", "Coalville", "Cockermouth", "Coggeshall", "Colchester", "Coleford", "Colne", "Congleton", "Conisbrough", "Corbridge", "Corby", "Cotgrave", "Coventry", "Cowes", "Cramlington", "Cranfield", "Crawley", "Crayford", "Crediton", "Crewe", "Crewkerne", "Cromer", "Crowborough", "Crowle", "Crowthorne", "Croydon", "Cuckfield", "Cullompton", "connor town", "Dagenham", "Dalton in Furness", "Darley Dale", "Darlington", "Dartford", "Dartmouth", "Darwen", "Daventry", "Dawlish", "Deal", "Denholme", "Denton", "Derby", "Dereham", "Desborough", "Devizes", "Dewsbury", "Didcot", "Dinnington", "Diss", "Doncaster", "Dorchester", "Dorking", "Dover", "Downham Market", "Driffield", "Dronfield", "Droitwich Spa", "Droylsden", "Dudley", "Dukinfield", "Dunstable", "Durham", "Dursley", "Ealing", "Earley", "Easingwold", "Eastbourne", "East Grinstead", "East Ham", "Eastleigh", "Eastwood", "Edenbridge", "Egham", "Ellesmere", "Ellesmere Port", "Ely", "Enfield", "Epping", "Epsom", "Epworth", "Erith", "Esher", "Eton", "Evesham", "Exeter", "Exmouth", "Eye", "Failsworth", "Fairford", "Fakenham", "Falmouth", "Fareham", "Faringdon", "Farnborough", "Farnham", "Farnworth", "Faversham", "Featherstone", "Felixstowe", "Fenny Stratford", "Ferndown", "Ferryhill", "Filey", "Filton", "Fleet", "Fleetwood", "Flitwick", "Folkestone", "Fordingbridge", "Fordwich", "Fowey", "Framlingham", "Frinton-on-Sea", "Frodsham", "Frome", "Foxley", "Gainsborough", "Gateshead", "Gillingham", "Gillingham", "Glastonbury", "Glossop", "Gloucester", "Godalming", "Godmanchester", "Goole", "Gosport", "Grange-over-Sands", "Grantham", "Gravesend", "Grays", "Great Dunmow", "Great Torrington", "Great Yarmouth", "Grimsby", "Guildford", "Guisborough", "Hackney", "Hadleigh", "Hailsham", "Halesworth", "Halewood", "Halifax", "Halstead", "Haltwhistle", "Harlow", "Harpenden", "Harrogate", "Harrow", "Hartlepool", "Harwich", "Haslemere", "Hastings", "Hatfield", "Havant", "Haverhill", "Hawley", "Hayle", "Haywards Heath", "Heanor", "Heathfield", "Hebden Bridge", "Hedon", "Helston", "Hemel Hempstead", "Hemsworth", "Henley-in-Arden", "Henley-on-Thames", "Hendon", "Hereford", "Herne Bay", "Hertford", "Hessle", "Heswall", "Hetton-le-Hole", "Heywood", "Hexham", "Higham Ferrers", "Highworth", "High Wycombe", "Hinckley", "Hitchin", "Hoddesdon", "Holmfirth", "Holsworthy", "Honiton", "Horley", "Horncastle", "Hornsea", "Horsham", "Horwich", "Houghton-le-Spring", "Hounslow", "Hoylake", "Hove", "Hucknall", "Huddersfield", "Hugh Town", "Hull", "Hungerford", "Hunstanton", "Huntingdon", "Hyde", "Hythe", "Ilchester", "Ilford", "Ilfracombe", "Ilkeston", "Ilkley", "Ilminster", "Ipswich", "Irthlingborough", "Ivybridge", "Jarrow", "Keighley", "Kempston", "Kendal", "Kenilworth", "Kesgrave", "Keswick", "Kettering", "Keynsham", "Kidderminster", "Kidsgrove", "Killingworth", "Kimberley", "Kingsbridge", "King's Lynn", "Kingston-upon-Hull", "Kingston upon Thames", "Kington", "Kirkby", "Kirkby-in-Ashfield", "Kirkby Lonsdale", "Kirkham", "Knaresborough", "Knottingley", "Knutsford", "Kingsteignton", "Lancaster", "Launceston", "Leatherhead", "Leamington Spa", "Lechlade", "Ledbury", "Leeds", "Leek", "Leicester", "Leigh", "Leighton Buzzard", "Leiston", "Leominster", "Letchworth", "Lewes", "Lewisham", "Leyland", "Leyton", "Lichfield", "Lincoln", "Liskeard", "Littlehampton", "Liverpool", "Lizard", "London", "London", "Long Eaton", "Longridge", "Looe", "Lostwithiel", "Loughborough", "Loughton", "Louth", "Lowestoft", "Ludlow", "Luton", "Lutterworth", "Lydd", "Lydney", "Lyme Regis", "Lymington", "Lynton", "Lytchett Minster", "Lytham St Annes", "Lofthouse", "Mablethorpe", "Macclesfield", "Maghull", "Maidenhead", "Maidstone", "Maldon", "Malmesbury", "Maltby", "Malton", "Malvern", "Manchester", "Manningtree", "Mansfield", "March", "Margate", "Market Deeping", "Market Drayton", "Market Harborough", "Market Rasen", "Market Weighton", "Marlborough", "Marlow", "Maryport", "Marston Moretaine", "Matlock", "Melksham", "Melton Mowbray", "Mexborough", "Middleham", "Middlesbrough", "Middleton", "Middlewich", "Midhurst", "Midsomer Norton", "Milton Keynes", "Minehead", "Morecambe", "Moretonhampstead", "Moreton-in-Marsh", "Morley", "Morpeth", "Much Wenlock", "Nailsea", "Nailsworth", "Nantwich", "Needham Market", "Nelson", "Neston", "Newark-on-Trent", "Newbiggin-by-the-Sea", "Newbury", "Newcastle-under-Lyme", "Newcastle upon Tyne", "Newent", "Newhaven", "Newmarket", "New Mills", "New Milton", "Newport", "Newport", "Shropshire", "Newport Pagnell", "Newquay", "New Romney", "Newton Abbot", "Newton Aycliffe", "Newton-le-Willows", "Normanton", "Northallerton", "Northam", "Northampton", "North Walsham", "Northwich", "Norton Radstock", "Norwich", "Nottingham", "Nuneaton", "Oakham", "Okehampton", "Oldbury", "Oldham", "Ollerton", "Olney", "Ormskirk", "Orpington", "Ossett", "Oswestry", "Otley", "Ottery St Mary", "Oundle", "Oxford", "Outwood", "Paddock Wood", "Padstow", "Paignton", "Painswick", "Peacehaven", "Penistone", "Penrith", "Penryn", "Penzance", "Pershore", "Peterborough", "Peterlee", "Petersfield", "Petworth", "Pickering", "Plymouth", "Pocklington", "Pontefract", "Polegate", "Poltimore", "Poole", "Portishead", "Portland", "Portslade", "Portsmouth", "Potters Bar", "Potton", "Poulton-le-Fylde", "Prescot", "Preston", "Princes Risborough", "Prudhoe", "Pudsey", "Queenborough", "Quintrell Downs", "Ramsgate", "Raunds", "Rayleigh", "Reading", "Redcar", "Redditch", "Redhill", "Redruth", "Reigate", "Retford", "Richmond", "Richmond-upon-Thames", "Rickmansworth", "Ringwood", "Ripley", "Ripon", "Rochdale", "Rochester", "Rochford", "Romford", "Romsey", "Ross-on-Wye", "Rothbury", "Rotherham", "Rothwell", "Rowley Regis", "Royston", "Rugby", "Rugeley", "Runcorn", "Rushden", "Rutland", "Ryde", "Rye", "Saffron Walden", "Selby", "St Albans", "St Asaph", "St Austell", "St Blazey", "St Columb Major", "St Helens", "St Ives", "Cambridgeshire", "St Ives", "Cornwall", "St Neots", "Salcombe", "Sale", "Salford", "Salisbury", "Saltash", "Saltburn-by-the-Sea", "Sandbach", "Sandhurst", "Sandown", "Sandwich", "Sandy", "Sawbridgeworth", "Saxmundham", "Scarborough", "Scunthorpe", "Seaford", "Seaton", "Sedgefield", "Selby", "Selsey", "Settle", "Sevenoaks", "Shaftesbury", "Shanklin", "Sheerness", "Sheffield", "Shepshed", "Shepton Mallet", "Sherborne", "Sheringham", "Shildon", "Shipston-on-Stour", "Shoreham-by-Sea", "Shrewsbury", "Sidcup", "Sidmouth", "Sittingbourne", "Skegness", "Skelmersdale", "Skipton", "Sleaford", "Slough", "Smethwick", "Snodland", "Soham", "Solihull", "Somerton", "Southall", "Southam", "Southampton", "Southborough", "Southend-on-Sea", "South Molton", "Southport", "Southsea", "South Shields", "Southwell", "Southwold", "South Woodham Ferrers", "Spalding", "Spennymoor", "Spilsby", "Stafford", "Staines", "Stainforth", "Stalybridge", "Stamford", "Stanley", "Stapleford", "Staunton", "Staveley", "Stevenage", "Stockport", "Stocksbridge", "Stockton-on-Tees", "Stoke-on-Trent", "Stone", "Stony Stratford", "Stotfold", "Stourbridge", "Stourport-on-Severn", "Stowmarket", "Stow-on-the-Wold", "Stratford-upon-Avon", "Streatham", "Street", "Strood", "Stroud", "Sudbury", "Sunderland", "Sutton", "Sutton Coldfield", "Sutton-in-Ashfield", "Swadlincote", "Swaffham", "Swanage", "Swanley", "Swindon", "Swinton", "Tadcaster", "Tadley", "Tamworth", "Taunton", "Tavistock", "Teignmouth", "Telford", "Tenbury Wells", "Tenterden", "Tetbury", "Tewkesbury", "Thame", "Thatcham", "Thaxted", "Thetford", "Thirsk", "Thong", "Thornaby", "Thornbury", "Thorne", "Tickhill", "Tilbury", "Tipton", "Tiverton", "Todmorden", "Tonbridge", "Torpoint", "Torquay", "Totnes", "Tottenham", "Totton", "Towcester", "Tring", "Trowbridge", "Truro", "Tunbridge Wells", "Twickenham", "Uckfield", "Ulverston", "Uppingham", "Upton-upon-Severn", "Uttoxeter", "Uxbridge", "Ventnor", "Verwood", "Wadebridge", "Wadhurst", "Wakefield", "Wallasey", "Wallingford", "Walmer", "Walsall", "Waltham Abbey", "Waltham Cross", "Walthamstow", "Walton-on-Thames", "Walton-on-the-Naze", "Wandsworth", "Wantage", "Ware", "Wareham", "Warminster", "Warwick", "Washington", "Watchet", "Watford", "Wath-upon-Dearne", "Watton", "Wednesbury", "Wellingborough", "Wellington", "Wells", "Wells-next-the-Sea", "Welwyn Garden City", "Wem", "Wendover", "West Bromwich", "Westbury", "Westerham", "West Ham", "Westhoughton", "West Kirby", "West Mersea", "Westminster", "Weston-super-Mare", "Westward Ho!", "Wetherby", "Weybridge", "Weymouth", "Whaley Bridge", "Whiston", "Whitby", "Whitchurch", "Whitehaven", "Whitley Bay", "Whitnash", "Whitstable", "Whitworth", "Wickford", "Widnes", "Wigan", "Wigston", "Willenhall", "Wimbledon", "Wimborne Minster", "Wincanton", "Winchcombe", "Winchelsea", "Winchester", "Windermere", "Winsford", "Winslow", "Wisbech", "Witham", "Withernsea", "Witney", "Wivenhoe", "Woburn", "Woking", "Wokingham", "Wolverhampton", "Wombwell", "Woodbridge", "Woodstock", "Wooler", "Woolwich", "Wootton Bassett", "Worcester", "Workington", "Worksop", "Worthing", "Wotton-under-Edge", "Wymondham" });

            foreach (string city in cities)
            {
                cityFinder.Add(city);
            }

            // Start main loop of searching for suggestions and valid next letters.
            string search = "";
            while (true)
            {
                ICityResult result = cityFinder.Search(search);

                DisplayNextCities(result.NextCities);
                DisplayLetters(result.NextLetters);
                search = GetUserInput(result.NextLetters, search);
            }
        }

        /// <summary>
        /// Display the given valid letter options to the user.
        /// </summary>
        /// <param name="letters">Letters to display.</param>
        static void DisplayLetters(ICollection<string> letters)
        {
            Console.Write("Next possible letters: ");
            foreach(string letter in letters)
            {
                Console.Write(letter);
            }
        }

        /// <summary>
        /// Display the suggested cities to the user.
        /// </summary>
        /// <param name="suggestedCities">Suggested cities to display.</param>
        static void DisplayNextCities(ICollection<string> suggestedCities)
        {
            Console.Write("\nSuggestions: ");
            foreach (string city in suggestedCities)
            {
                Console.Write(city + " - ");
            }

            Console.Write("\n\n\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validLetters"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        static string GetUserInput(ICollection<string> validLetters, string search)
        {
            Console.WriteLine("\n\nPlease start typing a city's name:\n" + search);

            // Get next letter from the user.
            char letter = Console.ReadKey().KeyChar;
            string checkSearch = search;

            // If the user has backspaced, remove the last character from the search term.
            if (letter == '\b' && checkSearch.Length >= 1)
            {
                checkSearch = checkSearch.Remove(checkSearch.Length - 1, 1);
            }
            else // Otherwise, add the next letter to the search term.
            {
                checkSearch = new string(search + letter);
            }

            // Make search term lower-case
            checkSearch = checkSearch.ToLower();

            Console.Clear();
            
            // If the new search term is valid, allow the new search term, otherwise return the old one.
            return CheckInputValid(checkSearch) ? checkSearch : search;
        }

        /// <summary>
        /// Uses a RegEx to only allow letters, spaces, and dashes when checking the input.
        /// </summary>
        /// <param name="input">Input to check</param>
        /// <returns>If the input is valid.</returns>
        public static bool CheckInputValid(string input)
        {
            return Regex.Match(input, "[a-zA-Z  -]+").Value.Equals(input);
        }
    }
}

import csv

def get_data():
    """Imports the csv-file, and appends each row (case) as a dictionary to a list. returns a list of libraries"""
    filename = 'tx_deathrow_full.csv'
    death_list = []
    with open(filename, newline='') as csvfile:
        death_reader = csv.reader(csvfile)
        for row in death_reader:
            cases = {'Execution': row[0], 'Date of Birth': row[1], 'Date of Offence': row[2], 
            'Highest Education Level': row[3], 'Last Name': row[4], 'First Name': row[5], 
            'TDCJ number': row[6], 'Age at Execution': row[7], 'Date Received': row[8], 'Execution Date': row[9], 
            'Race': row[10], 'County': row[11], 'Eye Color': row[12], 'Weight': row[13],
            'Height': row[14], 'Native County': row[15], 'Native State': row[16], 'Last Statement': row[17]}
            death_list.append(cases)
        del death_list[0]
        return death_list
imperial_list = get_data()
# print(imperial_list)

def to_metric(cases):
    """Takes a list of cases, (imperial_list), and converts the height and weight for each case to metric"""
    def convert_height(height):
        if height is None:
            return None
        try:
            feet, inches = height.split("'")
            feet = int(feet)
            inches = int(inches.strip()[:-1])
            return (feet * 30.48) + (inches * 2.54)
        except ValueError:
            return None
    return [{k: (float(v) / 2.2046) if (k == 'Weight' and v.isdigit()) else 
    (convert_height(v) if k == 'Height' else v) for k, v in case.items()} for case in cases]
metric_list = to_metric(imperial_list)
# print(metric_list)

def county_statistics(metric_list):
    """Takes a list of cases, and returns a new dictionary with each county as the key, and how many times the county is 
    represented in the dataset"""
    county_stats = {}
    for case in metric_list:
        county = case['County']
        if county not in county_stats:
            county_stats[county] = 1
        else:
            county_stats[county] += 1
    return county_stats
#print(county_statistics(metric_list))

def native_statistics(metric_list):
    """Takes a list of cases, and returns a new dictionary with each native county as the key, and how many times the native county is 
    represented in the dataset"""
    native_stats = {}
    for case in metric_list:
        native = case['Native County']
        if native not in native_stats:
            native_stats[native] = 1
        else:
            native_stats[native] += 1
    return native_stats
# print(native_statistics(metric_list))

def last_words_search(metric_list, words_and_sentences):
    """takes a list of cases, and a list of words and sentences, and returns a tuple with the inmates name, age of execution and last statement"""
    tup_list = []
    for case in metric_list:
        statement = (case['Last Statement']).lower()
        for word_or_sentence in words_and_sentences:
            if word_or_sentence.lower() in statement:
                tup_list.append((case['First Name'], case['Last Name'], case['Age at Execution'], case['Last Statement']))
    return tup_list

words_and_sentences = ["I guess that's allr.", "Ameen.", "Allah"]
test4 = last_words_search(metric_list, words_and_sentences)
# print(test4) 



        



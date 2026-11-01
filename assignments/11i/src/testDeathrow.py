import deathrow
import unittest
import csv

class TestDeathRowData(unittest.TestCase):
    def test_get_data(self):
        data = deathrow.get_data()
        self.assertIsInstance(data, list)
        self.assertIsInstance(data[0], dict)
        self.assertEqual(data[0]['Execution'], '553')
        self.assertEqual(data[0]['Date of Birth'], '1983-09-24')
        self.assertEqual(data[0]['Date of Offence'], '2004-11-21')

    def test_to_metric(self):
        
        cases = [{'Weight': '180', 'Height': '5\' 8"'}, {'Weight': '200', 'Height': '6\' 0"'}]
        expected = [{'Weight': 81.64746439263358, 'Height': 172.72}, {'Weight': 90.71940488070398, 'Height': 182.88}]
        self.assertEqual(deathrow.to_metric(cases), expected)
    
    def test_county_statistics(self):
       
        cases = [{'County': 'A'}, {'County': 'B'}, {'County': 'A'}, {'County': 'C'}]
        expected = {'A': 2, 'B': 1, 'C': 1}
        self.assertEqual(deathrow.county_statistics(cases), expected)
    
    def test_native_statistics(self):
        
        cases = [{'Native County': 'X'}, {'Native County': 'Y'}, {'Native County': 'X'}, {'Native County': 'Z'}]
        expected = {'X': 2, 'Y': 1, 'Z': 1}
        result = deathrow.native_statistics(cases)
        self.assertIsInstance(result, dict)
        self.assertEqual(result, expected)


    def test_last_words_search(self):
        words_and_sentences = ["I love you", "you", "love"]
        result = deathrow.last_words_search(deathrow.to_metric(deathrow.get_data()), words_and_sentences)
        self.assertEqual(type(result), list)
        self.assertEqual(all(isinstance(item, tuple) for item in result), True)
        self.assertEqual(all(len(item) == 4 for item in result), True)

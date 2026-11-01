import unittest
import pipeline
import operator
import csv

class TestAddConst(unittest.TestCase):
    def test_apply(self):
        add_const = pipeline.AddConst(5)
        self.assertEqual(add_const.apply(3), 8)
        self.assertEqual(add_const.apply(-2), 3)
    def test_get_c(self):
        add_const = pipeline.AddConst(5)
        self.assertEqual(add_const.get_c(), 5)
    def test_description(self):
        add_const = pipeline.AddConst(5)
        self.assertEqual(add_const.description(), "finder summen af to tal.")

class TestRepeater(unittest.TestCase):
    def test_apply(self):
        repeater = pipeline.Repeater(5)
        self.assertEqual(repeater.apply(3), [3, 3, 3, 3, 3])
        repeater = pipeline.Repeater(0)
        self.assertEqual(repeater.apply(3), [])

class TestGeneralSum(unittest.TestCase):
    def test_apply(self):
        general_sum = pipeline.GeneralSum(0, operator.add)
        self.assertEqual(general_sum.apply([1, 2, 3, 4, 5]), 15)
        general_sum = pipeline.GeneralSum(1, operator.mul)
        self.assertEqual(general_sum.apply([1, 2, 3, 4, 5]), 120)

class TestSumNum(unittest.TestCase):
    def test_apply(self):
        sum_num = pipeline.SumNum()
        self.assertEqual(sum_num.apply([1, 2, 3, 4, 5]), 15)
    def test_description(self):
        sum_num = pipeline.SumNum()
        self.assertEqual(sum_num.description(), "Kalder GeneralSum() med neutral = 0 og +-operator.")

class TestProductNum(unittest.TestCase):
    def test_apply(self):
        product_num = pipeline.ProductNum()
        self.assertEqual(product_num.apply([1, 2, 3, 4, 5]), 120)

class TestMap(unittest.TestCase):
    def test_apply(self):
        add_const = pipeline.AddConst(5)
        map = pipeline.Map(add_const)
        self.assertEqual(map.apply([1, 2, 3, 4]), [6, 7, 8, 9])

class TestSquare(unittest.TestCase):
    def test_apply(self):
        square = pipeline.Square(5)
        self.assertEqual(square.apply(), 25)

class TestCube(unittest.TestCase):
    def test_apply(self):
        cube = pipeline.Cube(5)
        self.assertEqual(cube.apply(), 125)

class TestSort(unittest.TestCase):
    def test_sort(self):
        sort = pipeline.Sort([3, 1, 2])
        self.assertEqual(sort.sort_(), [1, 2, 3])

class Testpc(unittest.TestCase):
    def test_apply(self):
        pipe = pipeline.Pipeline([pipeline.AddConst(1), pipeline.AddConst(2), pipeline.Repeater(2), pipeline.GeneralSum(2, operator.add), pipeline.AddConst(1)])
        self.assertEqual(pipe.apply(0), 9)

    def test_add_step(self):
        pipe = pipeline.Pipeline([pipeline.AddConst(1), pipeline.AddConst(2), pipeline.Repeater(2), pipeline.GeneralSum(2, operator.add)])
        pipe.add_step(pipeline.AddConst(1))
        self.assertEqual(pipe.apply(0), 9)


class TestCsvReader(unittest.TestCase):
    def test_apply(self):
        critter_data = pipeline.CsvReader('critters.csv')
        critter_apply_data = critter_data.apply()
        self.assertIsInstance(critter_apply_data, list)
        self.assertIsInstance(critter_apply_data[0], dict)
        self.assertEqual(critter_apply_data[0]['Name'], 'Poppy')
        self.assertEqual(critter_apply_data[1]['Name'], 'Aggie')
        self.assertEqual(critter_apply_data[3]['Colour'], 'pink')


class TestCritterStats(unittest.TestCase):
    def test_apply(self):
        critter_stats = pipeline.CritterStats(pipeline.critter_apply_data)
        colour_dict = critter_stats.apply()
        self.assertIsInstance(colour_dict, dict)
        self.assertGreater(len(colour_dict), 0)

if __name__ == '__main__':
    unittest.main()
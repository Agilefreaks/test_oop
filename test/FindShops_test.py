import unittest

class TestFindShopsMethods(unittest.TestCase):

    '''  on provided data 
    '''
    def test_nearby_shops(self):
        from find_nearby_shops import find_nearby_shops
        sol = find_nearby_shops([47.6, -122.4, './data/starbucks.csv']) 
        expected= {'Starbucks Seattle2': 0.0645, 'Starbucks Seattle': 0.0861, 'Starbucks SF': 10.0793}
        self.assertDictEqual ( sol, expected , '...shall be EQ as per https://github.com/Agilefreaks/test_oop') 

    ''' duplicate distance check 
    '''
    def test_nearby_shops_duplicate(self):
        from find_nearby_shops import find_nearby_shops
        sol = find_nearby_shops([47.6, -122.4, './data/test_same_distance.csv']) 
        a = list( sol.keys() )[0]
        b = 'Starbucks Seattle triplic and Starbucks Seattle duplic and Starbucks Seattle2'
        self.assertEqual ( a, b , '...shall be EQ ') 

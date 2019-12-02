import unittest

class TestShopsGeneratorMethods(unittest.TestCase):
    def test_distance_metric(self):
        from lib.ShopsCSV import ShopsCSV as Shops
        shops = Shops( './data/starbucks.csv' ).get_shops()
        sns = []
        for s in shops:
            (sn, c) = s
            sns.append(sn)

        sns_expected = [ 'Starbucks Seattle', 'Starbucks SF', 'Starbucks Moscow', 'Starbucks Seattle2', 'Starbucks Rio De Janeiro', 'Starbucks Sydney' ]

        self.assertListEqual (sns_expected , sns, 'EQ') 

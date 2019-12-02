import unittest

class TestLocationMethods(unittest.TestCase):

    ''' testing euclidian distance
    '''
    def test_distance_metric(self):
        from lib.Location import Location as gps
        a = gps([47.6, -122.4])
        b = gps([47.5809,-122.3160])
        d = a.dist_to(b)
        self.assertEqual (d , 0.0861, 'EQ') 


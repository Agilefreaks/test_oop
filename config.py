# logging stuffs
import logging 
logging.basicConfig()
log = logging.getLogger('logger')
log.setLevel(logging.INFO)

# custom librariers for shop generator and location
import sys
sys.path.append('./lib') 

from Location import Location
from ShopsCSV import ShopsCSV

# 
gps = Location
shops = ShopsCSV
N = 3    

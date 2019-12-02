import sys
from sortedcontainers import SortedDict

import config as config
log = config.log
gps = config.gps
shops_generator = config.shops
N = config.N

''' check arguments 
    iterates through shops and keep the closest config.N in sol
'''
def find_nearby_shops(args):
    try:
        a_coordinates = args[:-1]
        file_name = args[2]
    except Exception as e:
        log.error("Exception {e} \n{trace}".format(e=e, trace=e.__traceback__))

    ret = {}
    try:
        shops = shops_generator(file_name).get_shops()
        sol = SortedDict()
        
        for shop in shops:
            (shop_name, b_coordinates) = shop 
            d = gps( b_coordinates ).dist_to( gps(a_coordinates) ) 
            sol[d] = shop_name if d not in sol else shop_name + ' and ' + sol[d]
            if len(sol)>N:
                sol.pop( sol.keys()[-1] )

        ret = { v:k for k,v in dict( sol ).items() }
    except Exception as e:
        log.error("Exception {e} \n{trace}".format(e=e, trace=e.__traceback__))

    return ret
        

if __name__ == '__main__':
    args = sys.argv[1:]
    sol = find_nearby_shops(args) 
    print(sol)   
